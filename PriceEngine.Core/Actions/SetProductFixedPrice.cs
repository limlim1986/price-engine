using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;

namespace PriceEngine.Actions
{
    public class SetProductFixedPrice : IAction
    {
        public void Execute(Product product, int value)
        {
            product.SetPrice((decimal)value);
        }
    }
}
