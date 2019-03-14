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
            this.rules = rules;
            this.context = context;
        }

        public void ApplyRules()
        {
            var ruleEvaluator = new RuleEvaluator();
            var rulesThatApply = new List<Rule>();

            for (int i = 0; i < rules.Count; i++)
            {
                Rule rule = rules[i];
                bool applies = ruleEvaluator.CheckRule(rule, context);

                if (applies)
                    rulesThatApply.Add(rule);
            }
        }
    }

    public class RuleEvaluator
    {
        
        public bool CheckRule(Rule r, Context context)
        {
            var conditionsContainerChecker = new ConditionsContainerChecker();

            return conditionsContainerChecker.Check(r.Condition, context.Products);
        }
    }

    public class ConditionsContainerChecker
    {
        public bool Check(ConditionsContainer conditionContainer, Product[] products)
        {
            var productsWhereConditionsAreMet = new List<Product>();
            for(var i = 0; i < products.Length; i++)
            {
                var p = products[i];
                bool conditionsMet = CheckContainer(conditionContainer, p);

                if (conditionsMet)
                    productsWhereConditionsAreMet.Add(p);
            }      

            return productsWhereConditionsAreMet.Any();
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