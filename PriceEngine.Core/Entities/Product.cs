using PriceEngine.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PriceEngine.Core.Entities
{
    public class Product
    {
        public Product(IDictionary<string, dynamic> attributes, IEnumerable<AppliedRule> appliedRules)
        {
            Attributes = attributes.ToImmutableDictionary();
            RulesApplied = appliedRules.ToImmutableList();
        }
        
        public ImmutableDictionary<string, dynamic> Attributes { get; private set; }
        public ImmutableList<AppliedRule> RulesApplied { get; private set; }

        public Product SetPrice(decimal price)
        {
            return new Product(Attributes.SetItem("Price", price), RulesApplied);
        }

        public Product ApplyRule(AppliedRule appliedRule)
        {
            return new Product(Attributes, RulesApplied.Add(appliedRule));
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
