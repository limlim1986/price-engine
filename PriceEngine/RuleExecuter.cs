using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceEngine
{
    public class RuleExecuter
    {
        private readonly List<Rule> rules;
        private readonly Context context;

        public RuleExecuter(List<Rule> rules, Context context)
        {
            this.rules = rules.OrderBy(r => r.Priority).ToList();
            this.context = context;
        }

        public Product[] ApplyRules()
        {
            var ruleEvaluator = new RuleEvaluator();
            var poductsWithAppliedRules = new Product[context.Products.Length];

            for (int i = 0; i < context.Products.Length; i++)
            {
                poductsWithAppliedRules[i] = ruleEvaluator.ApplyRules(rules, context.Products[i]); ;
            }

            return poductsWithAppliedRules;
        }
    }

    public class RuleEvaluator
    {
        private ConditionsContainerChecker _conditionsContainerChecker;

        public RuleEvaluator()
        {
            _conditionsContainerChecker = new ConditionsContainerChecker();
        }
        public Product ApplyRules(List<Rule> rules, Product product)
        {
            foreach(var rule in rules)
            {
                var ruleApplies = _conditionsContainerChecker.Check(rule, product);

                if (ruleApplies)
                {
                    product.ExecuteAction(rule.Action);                 
                    product.RulesApplied.Add(rule.RuleId);

                    if (!rule.ContinueProcessing)
                        break;
                }
            }

            return product;
        }
    }

    public class ConditionsContainerChecker
    {
        public bool Check(Rule rule, Product product)
        {
            return CheckContainer(rule.Condition, product);
        }

        private static bool CheckContainer(ConditionsContainer container, Product p)
        {
            // Check conditions in current container
            bool conditionsMet = false;
            if(container.Type == ConditionContainerType.All)
            {
                for(int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = ConditionMet(container.Conditions[i], p);
                    if (!cm)
                        return false;
                }
            }
            else
            {
                for (int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = ConditionMet(container.Conditions[i], p);
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

        private static bool ConditionMet(Condition condition, Product p)
        {
            if (condition.Operator == "Equals")
            {
                return p.Attributes.GetValueOrDefault(condition.ContextPropertyName) == condition.Value;
            }

            if (condition.Operator == "GratherThanOrEqualTo")
            {
                return p.Attributes.GetValueOrDefault(condition.ContextPropertyName) >= condition.Value;
            }

            return false;
        }
    }
}