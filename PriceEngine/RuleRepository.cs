using PriceEngine.Core;
using System;
using System.Collections.Generic;

namespace PriceEngine
{
    public class RuleRepository : IRuleRepository
    {
        private List<Rule> _rules;

        public RuleRepository(IRuleGenerator ruleGenerator)
        {
            _rules = new List<Rule>();
            var random = new Random();

            for (int i = 1; i < 100; i++)
            {
                var prio = random.Next(20, 100);

                var r = ruleGenerator.GetRandomRule(i, prio);

                _rules.Add(r);
            }
        }

        public List<Rule> GetAll()
        {
            return _rules;
        }
    }

}