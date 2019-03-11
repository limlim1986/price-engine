using System;
using System.Collections.Generic;
using System.Linq;

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
            switch (r.Condition.Type)
            {
                case ConditionContainerType.All:
                    return conditionsContainerChecker.Check(r.Condition, context.Products);
                case ConditionContainerType.Any:
                    return false;
                default:
                    return false;
            }
        }
    }

    public class ConditionsContainerChecker
    {
        public bool Check(ConditionsContainer conditionContainer, List<Product> products)
        {
            var productsWhereAllConditionsApply = products.Where(p => conditionContainer.Conditions.)
            return conditionContainer.Conditions.All(c =>
            {
                if (c.Operator == "Equals")
                {
                    var pl = products.Where(p => p.Attributes.GetValueOrDefault(c.ContextPropertyName) == c.Value);
                    if (!pl.Any())
                        return false;
                }

                if (c.Operator == "GratherThanOrEqualTo")
                {
                    var pl = products.Where(p => p.Attributes.GetValueOrDefault(c.ContextPropertyName) >= c.Value);
                    if (!pl.Any())
                        return false;
                }

                return true;
            });

            //foreach(var c in conditionContainer.Conditions)
            //{
            //    foreach (var p in products)
            //    {
            //        if (c.Operator == "Equals")
            //        {
            //            var meetsCondition = v.Equals(c.Value);
            //            if (!meetsCondition)
            //                return false;
            //        }

            //        if (c.Operator == "GratherThanOrEqualTo")
            //        {
            //            var meetsCondition = v >= c.Value;
            //            if (!meetsCondition)
            //                return false;
            //        }
            //    }
            //}

            // I got all the way here so rule applies
            // return true;
            // any nested stuff?
            //if (allOrAny.AllOrAny.Any())
            //{
            //    foreach (var aoe in allOrAny.AllOrAny)
            //    {
            //        var passes = Check(aoe, context);
            //    }
            //}
        }
    }
}