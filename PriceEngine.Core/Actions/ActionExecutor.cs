using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core.Actions
{
    public class ActionExecutor : IActionExecutor
    {
        private readonly IActionStrategy actionStrategy;

        public ActionExecutor(IActionStrategy actionStrategy)
        {
            this.actionStrategy = actionStrategy;
        }

        public void ExecuteAction(Product product, Action action)
        {
            var a = actionStrategy.CreateAction(action.Type);
            a.Execute(product, action.Value);    
        }
    }
}
