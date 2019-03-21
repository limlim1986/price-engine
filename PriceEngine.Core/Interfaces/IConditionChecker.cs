using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IConditionChecker
    {
        bool Check(Condition condition, Product p);
    }
}