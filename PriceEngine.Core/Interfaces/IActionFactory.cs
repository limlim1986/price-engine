using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IActionFactory
    {
        IAction CreateAction();
        bool AppliesTo(ActionType type);
    }
}
