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
            foreach(var rule in rules)
            {
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
        public bool Check(ConditionsContainer conditionContainer, List<Product> products)
        {
            var productsWhereConditionsAreMet = new List<Product>();
            products.ForEach(p =>
            {
                bool conditionsMet = CheckContainer(conditionContainer, p);

                if (conditionsMet)
                    productsWhereConditionsAreMet.Add(p);
            });          

            return productsWhereConditionsAreMet.Any();
        }

        private static bool CheckContainer(ConditionsContainer container, Product p)
        {
            // Check conditions in current container
            bool conditionsMet = false;
            if(container.Type == ConditionContainerType.All)
            {
                conditionsMet = container.Conditions.All(c => ConditionMet(c, p));

                if (!conditionsMet)
                    return false;
            }
            else
            {
                conditionsMet = container.Conditions.Any(c => ConditionMet(c, p));

                if (conditionsMet)
                    return true;
            }

            
            // Check conditions in nested containers recursivley
            if (container.ConditionContainers != null && container.ConditionContainers.Any())
            {
                foreach (var cc in container.ConditionContainers)
                {
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