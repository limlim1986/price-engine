using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriceEngine
{
    class Program
    {
        private static RuleExecuter _re;

        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var ruleRepository = new RuleRepository();
            var context = new Context
            {
                Products = productRepository.GetAll().ToArray(),
                Customer = new Customer { Age = 100, Name = "Liam" }
            };
            var rules = ruleRepository.GetAll();
            _re = new RuleExecuter(rules, context);

            RunRules();           
        }

        private static void RunRules()
        {
            var sw = Stopwatch.StartNew();                    
            var pwar = _re.ApplyRules();
            sw.Stop();
            Console.WriteLine($"Executed in {sw.ElapsedMilliseconds}ms");

            var k = Console.ReadKey();

            if (k.KeyChar.Equals('r'))
                RunRules();
        }
    }
}
