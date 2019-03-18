using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Core.Operators
{
    public class LessThanCheck : IOperatorCheck
    {
        public LessThanCheck()
        {
            HandlesOperator = OperatorConstant.LessThan;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            return attributeValue < conditionValue;
        }
    }
}
