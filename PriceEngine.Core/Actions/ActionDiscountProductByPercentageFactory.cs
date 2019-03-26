using PriceEngine.Actions;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core.Actions
{
    public class ActionDiscountProductByPercentageFactory : IActionFactory
    {
        public bool AppliesTo(ActionType type)
        {
            return type == ActionType.DiscountPercentage;
        }

        public IAction CreateAction()
        {
            return new DiscountProductByPercentage();
        }
    }
}
