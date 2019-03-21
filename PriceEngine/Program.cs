using PriceEngine.Actions;
using PriceEngine.Core;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Operators;
using System;
using System.Collections.Generic;
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
            _re = new RuleApplier ( 
                new RuleEvaluator (
                    new ActionExecutor (
                        new List<IAction> { new DiscountProductByFixedAmount(), new DiscountProductByPercentage(), new SetProductFixedPrice() }
                        ),
                    new ConditionsContainerChecker (
                        new ConditionChecker (
                            new List<IOperatorCheck> { new EqualsCheck(), new GreaterThanCheck(), new InCheck(), new LessThanCheck(), new NotInCheck() }
                        )
                    )
                )
            );

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
