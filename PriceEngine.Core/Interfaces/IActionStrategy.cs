using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IActionStrategy
    {
        IAction CreateAction(ActionType type);
    }
}
