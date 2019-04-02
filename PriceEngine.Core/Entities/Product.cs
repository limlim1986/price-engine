using PriceEngine.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PriceEngine.Core.Entities
{
    public class Product
    {
        public Product(Dictionary<string, dynamic> attributes, List<AppliedRule> appliedRules)
        {
            Attributes = attributes;
            RulesApplied = appliedRules;
        }
        
        public Dictionary<string, dynamic> Attributes { get; private set; }
        public IList<AppliedRule> RulesApplied { get; private set; }

        public void SetPrice(decimal price)
        {
            Attributes["Price"] = price;
        }

        public void ApplyRules(Rule[] rules)
        {
            for (int i = 0; i < rules.Length; i++)
            {
                var rule = rules[i];
                if (rule.AppliesTo(this))
                {
                    var ar = new AppliedRule
                    {
                        Rule = rule,
                        PriceBeforeRuleWasApplied = Attributes["Price"],
                    };

                    rule.ExecuteAction(this);
                    ar.PriceAfterRuleWasApplied = Attributes["Price"];

                    RulesApplied.Add(ar);

                    if (!rule.ContinueProcessing)
                        break;
                }
            }
        }
    }
}
