using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core
{
    public class RuleEvaluator : IRuleEvaluator
    {
        private IActionExecutor _actionExecutor;
        private IConditionsContainerChecker _conditionsContainerChecker;

        public RuleEvaluator(IActionExecutor actionExecutor, IConditionsContainerChecker conditionsContainerChecker)
        {
            _actionExecutor = actionExecutor;
            _conditionsContainerChecker = conditionsContainerChecker;
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