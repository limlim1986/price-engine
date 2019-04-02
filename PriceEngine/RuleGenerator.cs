using PriceEngine.Core;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Operators;
using System.Collections.Generic;
using System.Linq;
using Action = PriceEngine.Core.Entities.Action;

namespace PriceEngine
{
    public class RuleGenerator : IRuleGenerator
    {
        private IEnumerable<IOperatorCheck> _operatorCheckers;
        public RuleGenerator(IEnumerable<IOperatorCheck> operatorCheckers)
        {
            _operatorCheckers = operatorCheckers;
        }

        public Rule GetRandomRule(int id, int prio)
        {
            if (id % 2 == 0)
                return GetConditionsOnlyRule(id, prio);

            return GetRuleWithConditionContainers(id, prio);
        }

        private Rule GetConditionsOnlyRule(int id, int prio)
        {          
            return new Rule
            {
                RuleId = id,
                Name = "10% off for all products that cost 10",
                Action = new Action { Type = ActionType.DiscountFixedAmount, Value = 1 },
                ContinueProcessing = true,
                Priority = prio,
                Condition = new ConditionsContainer(ConditionContainerType.All, GetConditions())
            };
        }

        private Rule GetRuleWithConditionContainers(int id, int prio)
        {       
            var conditionContainers = new List<ConditionsContainer>
            {
                new ConditionsContainer(ConditionContainerType.All, GetConditions()),
                new ConditionsContainer(ConditionContainerType.Any, GetConditions())
            };

            return new Rule
            {
                RuleId = id,
                Name = "10% off for all products that cost 10",
                Action = new Action { Type = ActionType.DiscountFixedAmount, Value = 1 },
                ContinueProcessing = true,
                Priority = prio,
                Condition = new ConditionsContainer(ConditionContainerType.All, conditionContainers)
            };
        }

        private List<Condition> GetConditions()
        {
            var equalsOperatorChecker = _operatorCheckers.FirstOrDefault(oc => oc.HandlesOperator == OperatorConstant.Equals);
            var greaterThanOperatorChecker = _operatorCheckers.FirstOrDefault(oc => oc.HandlesOperator == OperatorConstant.GreaterThan);
            return new List<Condition>
            {
                new Condition(equalsOperatorChecker, "Red", "Color"),
                new Condition(greaterThanOperatorChecker, 1M, "Price"),
                new Condition(greaterThanOperatorChecker, 1M, "Price"),
                new Condition(greaterThanOperatorChecker, 1M, "Price"),
                new Condition(greaterThanOperatorChecker, 1M, "Price"),
                new Condition(greaterThanOperatorChecker, 1M, "Price"),
            };
        }
    }

}