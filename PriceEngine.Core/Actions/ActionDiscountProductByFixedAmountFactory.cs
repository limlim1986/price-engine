using PriceEngine.Actions;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core.Actions
{
    public class ActionDiscountProductByFixedAmountFactory : IActionFactory
    {
        public bool AppliesTo(ActionType type)
        {
            return type == ActionType.DiscountFixedAmount;
        }

        public IAction CreateAction()
        {
            return new DiscountProductByFixedAmount();
        }
    }
}
