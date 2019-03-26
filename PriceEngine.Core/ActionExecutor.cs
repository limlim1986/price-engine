using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core
{
    public class ActionExecutor : IActionExecutor
    {
        private readonly IActionStrategy actionStrategy;

        public ActionExecutor(IActionStrategy actionStrategy)
        {
            this.actionStrategy = actionStrategy;
        }

        public Product ExecuteAction(Product product, Action action)
        {
            var a = actionStrategy.CreateAction(action.Type);
            product = a.Execute(product, action.Value);
      
            return product;
        }
    }
}
