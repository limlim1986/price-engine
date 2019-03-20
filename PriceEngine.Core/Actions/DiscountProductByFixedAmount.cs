using PriceEngine.Core;
using PriceEngine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Actions
{
    public class DiscountProductByFixedAmount : IAction
    {
        public DiscountProductByFixedAmount()
        {
            Type = ActionType.DiscountFixedAmount;
        }

        public ActionType Type { get; private set; }
        public Product Execute(Product product, int value)
        {
            product.Attributes["Price"] -= (decimal)value;
            return product;
        }
    }
}
