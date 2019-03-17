using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Actions
{
    public class SetProductFixedPrice : IAction
    {
        public SetProductFixedPrice()
        {
            Type = ActionType.SetFixedPrice;
        }

        public ActionType Type { get; private set; }
        public Product Execute(Product product, int value)
        {
            product.Attributes["Price"] = (decimal)value;
            return product;
        }
    }
}
