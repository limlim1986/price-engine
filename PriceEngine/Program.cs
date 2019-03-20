using PriceEngine.Core;
using PriceEngine.Core.Entities;
using System;
using System.Diagnostics;

namespace PriceEngine
{
    class Program
    {
        private static Product[] products;
        private static Rule[] rules;
        private static RuleApplier _re;

        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var ruleRepository = new RuleRepository();
            var context = new Context
            {
                Customer = new Customer { Age = 100, Name = "Liam" }
            };

            products = productRepository.GetAll().ToArray();
            rules = ruleRepository.GetAll().ToArray();
            _re = new RuleApplier();

            RunRules();           
        }

        private static void RunRules()
        {
            var sw = Stopwatch.StartNew();                    
            var pwar = _re.ApplyRules(rules, products);
            sw.Stop();

            Console.WriteLine($"Executed in {sw.ElapsedMilliseconds}ms");

            var k = Console.ReadKey();

            if (k.KeyChar.Equals('r'))
                RunRules();
        }
    }
}
