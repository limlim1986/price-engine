using PriceEngine.Core.Operators;
using System;

namespace PriceEngine.Core.Entities
{
    public class Condition
    {
        public Condition(IOperatorCheck operatorCheck, dynamic value, string contextPropertyName)
        {
            if (operatorCheck == null)
                throw new ArgumentNullException(nameof(operatorCheck));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (contextPropertyName == null)
                throw new ArgumentNullException(nameof(contextPropertyName));
            if (string.IsNullOrWhiteSpace(contextPropertyName))
                throw new ArgumentException($"{nameof(contextPropertyName)} must not be empty string");

            OperatorChecker = operatorCheck;
            Value = value;
            ContextPropertyName = contextPropertyName;
        }

        public IOperatorCheck OperatorChecker { get; private set; }
        public dynamic Value { get; private set; }
        public string ContextPropertyName { get; private set; }

        public bool Check(Product p)
        {         
            return OperatorChecker.Check(p.Attributes[ContextPropertyName], Value);
        }
    }
}
