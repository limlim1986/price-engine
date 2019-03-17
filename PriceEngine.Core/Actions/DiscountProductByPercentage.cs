using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Actions
{
    public class DiscountProductByPercentage : IAction
    {
        public DiscountProductByPercentage()
        {
            Type = ActionType.DiscountPercentage;
        }

        public ActionType Type { get; private set; }
        public Product Execute(Product product, int value)
        {
            product.Attributes["Price"] = decimal.Multiply(product.Attributes["Price"], 1M - (0.01M * value));
            return product;
        }
    }
}
