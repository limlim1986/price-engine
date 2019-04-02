using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Actions
{
    public class DiscountProductByFixedAmount : IAction
    {
        public void Execute(Product product, int value)
        {
            product.SetPrice(product.Attributes["Price"] - (decimal)value);
        }
    }
}
