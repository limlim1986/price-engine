using System;
using System.Collections.Generic;

namespace PriceEngine.Core.Entities
{
    public class Product
    {
        private IList<AppliedRule> appliedRules = new List<AppliedRule>();
        private decimal price;

        public Product(Dictionary<string, dynamic> attributes, decimal price)
        {
            Attributes = attributes;
            this.price = price;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public Dictionary<string, dynamic> Attributes { get; private set; }

        public void SetPrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException($"{nameof(newPrice)} must not be negative");

            price = newPrice;
        }

        public void ApplyRules(List<Rule> rules)
        {
            foreach (var rule in rules)
            {
                if (rule.AppliesTo(this))
                {
                    var ar = new AppliedRule
                    {
                        Rule = rule,
                        PriceBeforeRuleWasApplied = price,
                    };

                    rule.ExecuteAction(this);
                    ar.PriceAfterRuleWasApplied = price;

                    appliedRules.Add(ar);

                    if (!rule.ContinueProcessing)
                        break;
                }
            }
        }
    }
}
