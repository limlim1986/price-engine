using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core.Entities
{
    public class ProductCollection
    {
        private readonly List<Product> products;

        public ProductCollection(List<Product> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));
            if (!products.Any())
                throw new ArgumentException($"{nameof(products)} must not be an empty list");

            this.products = products;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> ApplyRules(List<Rule> rules)
        {
            var orderedRules = rules.OrderBy(r => r.Priority).ToList();
            foreach (Product p in products)
            {
                p.ApplyRules(orderedRules);
            }

            return products;
        }
    }
}
