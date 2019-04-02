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

        public void ApplyRule(AppliedRule appliedRule)
        {
            RulesApplied.Add(appliedRule);
        }

        public void Visit(IProductVisitor visitor)
        {
            visitor.Execute(this);
        }
    }

    public class ConcreteVisitor : IProductVisitor
    {
        private readonly AppliedRule _appliedRule;

        public ConcreteVisitor(AppliedRule appliedRule)
        {
            _appliedRule = appliedRule;
        }

        public void Execute(Product product)
        {
            product.ApplyRule(_appliedRule);
        }
    }
}
