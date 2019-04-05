using Microsoft.Extensions.DependencyInjection;
using PriceEngine.Core;
using PriceEngine.Core.Actions;
using PriceEngine.Core.Actions.Factories;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using PriceEngine.Core.Operators;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriceEngine
{
    class Program
    {
        private static ProductCollection productCollection;
        private static List<Rule> rules;

        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IActionStrategy, ActionStrategy>()
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

            productCollection = productRepository.GetAll();
            rules = ruleRepository.GetAll();

            RunRules();           
        }

        private static void RunRules()
        {
            var sw = Stopwatch.StartNew();                    
            var pwar = productCollection.ApplyRules(rules);
            sw.Stop();

            Console.WriteLine($"Executed in {sw.ElapsedMilliseconds}ms");

            var k = Console.ReadKey();

            if (k.KeyChar.Equals('r'))
                RunRules();
        }
    }
}
