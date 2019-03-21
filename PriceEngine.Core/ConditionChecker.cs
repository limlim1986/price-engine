using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using PriceEngine.Core.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core
{
    public class ConditionChecker : IConditionChecker
    {
        private List<IOperatorCheck> _operatorCheckers;

        public ConditionChecker(List<IOperatorCheck> operatorCheckers)
        {
            _operatorCheckers = operatorCheckers;
        }

        public bool Check(Condition condition, Product p)
        {
            var operatorChecker = _operatorCheckers.FirstOrDefault(oc => oc.HandlesOperator == condition.Operator);
            return operatorChecker.Check(p.Attributes[condition.ContextPropertyName], condition.Value);
        }
    }
}