using PriceEngine.Core.Entities;

namespace PriceEngine.Core
{
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
}