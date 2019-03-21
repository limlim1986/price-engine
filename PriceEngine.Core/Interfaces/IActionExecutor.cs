using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IActionExecutor
    {
        Product ExecuteAction(Product product, Action action);
    }
}