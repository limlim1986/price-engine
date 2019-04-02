using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IAction
    {
        void Execute(Product product, int value);
    }
}
