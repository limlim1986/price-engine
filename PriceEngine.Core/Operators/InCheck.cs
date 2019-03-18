﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceEngine.Core.Operators
{
    public class InCheck : IOperatorCheck
    {
        public InCheck()
        {
            HandlesOperator = OperatorConstant.In;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            var list = ((string)conditionValue).Split(',');
            return list.Any(s => s.Equals(attributeValue));
        }
    }
}
