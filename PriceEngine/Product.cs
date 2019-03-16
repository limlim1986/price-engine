using System;
using System.Collections.Generic;

namespace PriceEngine
{
    public class Product
    {
        public Product()
        {
            RulesApplied = new List<int>();
        }

        public Dictionary<string, dynamic> Attributes { get; set; }
        public List<int> RulesApplied { get; set; }
    }
}
