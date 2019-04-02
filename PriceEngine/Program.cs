using Microsoft.Extensions.DependencyInjection;
using PriceEngine.Core;
using PriceEngine.Core.Actions;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using PriceEngine.Core.Operators;
using System;
using System.Diagnostics;

namespace PriceEngine
{
    class Program
    {
        private static Product[] products;
        private static Rule[] rules;
        private static IRuleApplier _re;

        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IActionStrategy, ActionStrategy>()
                .AddSingleton<IRuleApplier, RuleApplier>()
                .AddSingleton<IRuleEvaluator, RuleEvaluator>()
                .AddSingleton<IActionExecutor, ActionExecutor>()
                .AddSingleton<IActionFactory, ActionDiscountProductByFixedAmountFactory>()
                .AddSingleton<IActionFactory, ActionDiscountProductByPercentageFactory>()
                .AddSingleton<IActionFactory, ActionSetProductFixedPriceFactory>()
                .AddSingleton<IOperatorCheck, EqualsCheck>()
                .AddSingleton<IOperatorCheck, GreaterThanCheck>()
                .AddSingleton<IOperatorCheck, LessThanCheck>()
                .AddSingleton<IOperatorCheck, InCheck>()
                .AddSingleton<IOperatorCheck, NotInCheck>()
                .AddSingleton<IRuleRepository, RuleRepository>()
                .AddSingleton<IRuleGenerator, RuleGenerator>()
                .BuildServiceProvider();

            var productRepository = new ProductRepository();
            var ruleRepository = serviceProvider.GetService<IRuleRepository>();
            var context = new Context
            {
                Customer = new Customer { Age = 100, Name = "Liam" }
            };

            products = productRepository.GetAll().ToArray();
            rules = ruleRepository.GetAll().ToArray();
            _re = serviceProvider.GetService<IRuleApplier>();

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
