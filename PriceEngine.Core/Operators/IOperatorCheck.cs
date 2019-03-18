namespace PriceEngine.Core.Operators
{
    public interface IOperatorCheck
    {
        OperatorConstant HandlesOperator { get; }
        bool Check(dynamic attributeValue, dynamic conditionValue);
    }
}