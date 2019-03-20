using PriceEngine.Actions;
using PriceEngine.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core
{
    public class ActionExecutor
    {
        private readonly List<IAction> _actionsList;
        public ActionExecutor()
        {
            _actionsList = new List<IAction>
            {
                new DiscountProductByPercentage(),
                new DiscountProductByFixedAmount(),
                new SetProductFixedPrice()
            };
        }

        public Product ExecuteAction(Product product, Action action)
        {
            var executor = _actionsList.SingleOrDefault(a => a.Type == action.Type);
            product = executor.Execute(product, action.Value);
      
            return product;
        }
    }
}
