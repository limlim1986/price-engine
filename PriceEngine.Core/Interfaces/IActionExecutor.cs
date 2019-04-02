using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IActionExecutor
    {
        void ExecuteAction(Product product, Action action);
    }
}