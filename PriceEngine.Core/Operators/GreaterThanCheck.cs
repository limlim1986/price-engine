using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Core.Operators
{
    public class GreaterThanCheck : IOperatorCheck
    {
        public GreaterThanCheck()
        {
            HandlesOperator = OperatorConstant.GratherThan;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            return attributeValue > conditionValue;
        }
    }
}
