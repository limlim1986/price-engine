using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Actions
{
    public class DiscountProductByPercentage : IAction
    {
        public Product Execute(Product product, int value)
        {
            return product.SetPrice(decimal.Multiply(product.Attributes["Price"], 1M - (0.01M * value)));
        }
    }
}
