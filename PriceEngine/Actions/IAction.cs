using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Actions
{
    public interface IAction
    {
        Product Execute(Product product, int value);
    }
}
