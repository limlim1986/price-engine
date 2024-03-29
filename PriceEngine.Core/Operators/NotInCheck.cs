﻿using System.Linq;

namespace PriceEngine.Core.Operators
{
    public class NotInCheck : IOperatorCheck
    {
        public NotInCheck()
        {
            HandlesOperator = OperatorConstant.NotIn;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            var list = ((string)conditionValue).Split(',');
            return !list.Any(s => s.Equals(attributeValue));
        }
    }
}
