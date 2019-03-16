using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine
{
    public class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
            var random = new Random();
            for (int i = 0; i < 5000; i++)
            {
                var p = new Product
                {
                    Attributes = new Dictionary<string, dynamic>
                    {
                        { "ProductId", i },
                        { "Name", "iPhone 7" },
                        { "Price", random.Next(100, 15000) },
                        { "Color", "Red" },
                        { "Memory", 32 },
                        { "HasEsim", true }
                    }
                };

                _products.Add(p);
            }    
        }
        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
