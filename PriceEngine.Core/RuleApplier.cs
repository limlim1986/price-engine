using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System.Linq;

namespace PriceEngine.Core
{
    public class RuleApplier : IRuleApplier
    {
        private IRuleEvaluator _ruleEvaluator;

        public RuleApplier()
        {
            _ruleEvaluator = new RuleEvaluator();
        }
        public Product[] ApplyRules(Rule[] rules, Product[] products)
        {       
            rules = rules.OrderBy(r => r.Priority).ToArray();
            
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = _ruleEvaluator.ApplyRules(rules, products[i]);
            }

            return products;
        }
    }
}