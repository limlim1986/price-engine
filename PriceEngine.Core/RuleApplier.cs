using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System.Linq;

namespace PriceEngine.Core
{
    public class RuleApplier : IRuleApplier
    {
        public Product[] ApplyRules(Rule[] rules, Product[] products)
        {       
            rules = rules.OrderBy(r => r.Priority).ToArray();
            
            for (int i = 0; i < products.Length; i++)
            {
                products[i].ApplyRules(rules);
            }

            return products;
        }
    }
}