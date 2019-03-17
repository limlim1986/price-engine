using PriceEngine.Actions;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine
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
