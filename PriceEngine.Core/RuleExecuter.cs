using PriceEngine.Core.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceEngine.Core
{
    public class RuleExecuter
    {
        public Product[] ApplyRules(Rule[] rules, Product[] products)
        {       
            rules = rules.OrderBy(r => r.Priority).ToArray();
            var ruleEvaluator = new RuleEvaluator();

            for (int i = 0; i < products.Length; i++)
            {
                products[i] = ruleEvaluator.ApplyRules(rules, products[i]);
            }

            return products;
        }
    }

    public class RuleEvaluator
    {
        private ActionExecutor _actionExecutor;
        private ConditionsContainerChecker _conditionsContainerChecker;

        public RuleEvaluator()
        {
            _actionExecutor = new ActionExecutor();
            _conditionsContainerChecker = new ConditionsContainerChecker();
        }
        public Product ApplyRules(Rule[] rules, Product product)
        {
            for (int i = 0; i < rules.Length; i++)
            {
                Rule rule = rules[i];
                var ruleApplies = _conditionsContainerChecker.Check(rule, product);

                if (ruleApplies)
                {
                    var ar = new AppliedRule
                    {
                        Rule = rule,
                        PriceBeforeRuleWasApplied = product.Attributes["Price"],
                    };

                    product = _actionExecutor.ExecuteAction(product, rule.Action);
                    ar.PriceAfterRuleWasApplied = product.Attributes["Price"];

                    product.RulesApplied.Add(ar);

                    if (!rule.ContinueProcessing)
                        break;
                }
            }

            return product;
        }
    }

    public class ConditionsContainerChecker
    {
        private readonly ConditionChecker _conditionChecker;

        public ConditionsContainerChecker()
        {
            _conditionChecker = new ConditionChecker();
        }

        public bool Check(Rule rule, Product product)
        {
            return CheckContainer(rule.Condition, product);
        }

        private bool CheckContainer(ConditionsContainer container, Product p)
        {
            bool conditionsMet = false;
            if(container.Type == ConditionContainerType.All)
            {
                for(int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = _conditionChecker.Check(container.Conditions[i], p);
                    if (!cm)
                        return false;
                }
            }
            else
            {
                for (int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = _conditionChecker.Check(container.Conditions[i], p);
                    if (cm)
                        return true;
                }
            }

            
            // Check conditions in nested containers recursivley
            if (container.ConditionContainers != null && container.ConditionContainers.Any())
            {
                for (int i = 0; i < container.ConditionContainers.Count; i++)
                {
                    ConditionsContainer cc = container.ConditionContainers[i];
                    conditionsMet = CheckContainer(cc, p);

                    if(cc.Type == ConditionContainerType.All)
                    {
                        if (!conditionsMet)
                            return false;
                    }
                    else
                    {
                        if (conditionsMet)
                            return true;
                    }
                }
            }

            return true;
        }
    }
}