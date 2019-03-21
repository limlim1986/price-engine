using PriceEngine.Actions;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core
{
    public class ActionExecutor : IActionExecutor
    {
        private readonly List<IAction> _actionsList;
        public ActionExecutor(List<IAction> actionsList)
        {
            _actionsList = actionsList;
        }

        public Product ExecuteAction(Product product, Action action)
        {
            var executor = _actionsList.SingleOrDefault(a => a.Type == action.Type);
            product = executor.Execute(product, action.Value);
      
            return product;
        }
    }
}
