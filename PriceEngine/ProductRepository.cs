using PriceEngine.Core.Entities;
using System;
using System.Collections.Generic;

namespace PriceEngine
{
    public class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var p = new Product(new Dictionary<string, dynamic> {
                        { "ProductId", i },
                        { "Name", "iPhone 7" },
                        { "Color", "Red" },
                        { "Memory", 32 },
                        { "HasEsim", true }
                    }, random.Next(100, 15000));

                _products.Add(p);
            }    
        }
        public ProductCollection GetAll()
        {
            return new ProductCollection(_products);
        }
    }
}
