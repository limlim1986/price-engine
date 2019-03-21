using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IConditionsContainerChecker
    {
        bool Check(Rule rule, Product product);
    }
}