using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Core.Operators
{
    public class EqualsCheck : IOperatorCheck
    {
        public EqualsCheck()
        {
            HandlesOperator = OperatorConstant.Equals;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            return attributeValue == conditionValue;
        }
    }
}
