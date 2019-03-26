﻿using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Actions
{
    public class DiscountProductByFixedAmount : IAction
    {
        public Product Execute(Product product, int value)
        {
            product.Attributes["Price"] -= (decimal)value;
            return product;
        }
    }
}
