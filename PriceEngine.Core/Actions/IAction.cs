using PriceEngine.Core;
using PriceEngine.Core.Entities;

namespace PriceEngine.Actions
{
    public interface IAction
    {
        ActionType Type { get; }
        Product Execute(Product product, int value);
    }
}
