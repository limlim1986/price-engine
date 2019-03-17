using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Actions
{
    public interface IAction
    {
        ActionType Type { get; }
        Product Execute(Product product, int value);
    }
}
