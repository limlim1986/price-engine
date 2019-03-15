using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriceEngine
{
    class Program
    {
        static void Main(string[] args)
        {         
            RunRules();           
        }

        private static void RunRules()
        {
            var sw = Stopwatch.StartNew();
            var productRepository = new ProductRepository();
            var ruleRepository = new RuleRepository();
            var context = new Context
            {
                Products = productRepository.GetAll().ToArray(),
                Customer = new Customer { Age = 100, Name = "Liam" }
            };
            var rules = ruleRepository.GetAll();

            var re = new RuleExecuter(rules, context);

            var pwar = re.ApplyRules();

            sw.Stop();
            Console.WriteLine($"Executed in {sw.ElapsedMilliseconds}ms");

            var k = Console.ReadKey();

            if (k.KeyChar.Equals('r'))
                RunRules();
        }
    }
}
