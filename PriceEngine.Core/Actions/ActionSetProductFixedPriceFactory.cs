using PriceEngine.Actions;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Core.Actions
{
    public class ActionSetProductFixedPriceFactory : IActionFactory
    {
        public bool AppliesTo(ActionType type)
        {
            return type == ActionType.SetFixedPrice;
        }

        public IAction CreateAction()
        {
            return new SetProductFixedPrice();
        }
    }
}
