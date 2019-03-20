namespace PriceEngine.Core.Operators
{
    public class GreaterThanCheck : IOperatorCheck
    {
        public GreaterThanCheck()
        {
            HandlesOperator = OperatorConstant.GreaterThan;
        }

        public OperatorConstant HandlesOperator { get; private set; }

        public bool Check(dynamic attributeValue, dynamic conditionValue)
        {
            return attributeValue > conditionValue;
        }
    }
}
