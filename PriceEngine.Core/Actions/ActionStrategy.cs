using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core.Actions
{
    public class ActionStrategy : IActionStrategy
    {
        private readonly IEnumerable<IActionFactory> _actionFactories;

        public ActionStrategy(IEnumerable<IActionFactory> actionFactories)
        {
            _actionFactories = actionFactories;
        }
        public IAction CreateAction(ActionType type)
        {
            var factory = _actionFactories.SingleOrDefault(f => f.AppliesTo(type));

            return factory.CreateAction();
        }
    }
}
