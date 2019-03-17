using System;
using System.Collections.Generic;

namespace PriceEngine
{
    public class Product
    {
        public Product()
        {
            RulesApplied = new List<AppliedRule>();
        }
        
        public Dictionary<string, dynamic> Attributes { get; set; }
        public List<AppliedRule> RulesApplied { get; set; }
    }
}
