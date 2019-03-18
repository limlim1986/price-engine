﻿using PriceEngine.Core;
using PriceEngine.Core.Operators;

namespace PriceEngine.Core
{
    public class Condition
    {
        public OperatorConstant Operator { get; set; }
        public dynamic Value { get; set; }
        public string ContextPropertyName { get; set; }
    }
}
