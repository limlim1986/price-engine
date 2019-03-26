using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IAction
    {
        Product Execute(Product product, int value);
    }
}
