using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Actions
{
    public class SetProductFixedPrice : IAction
    {
        public Product Execute(Product product, int value)
        {
            return product.SetPrice((decimal)value);
        }
    }
}
