namespace PriceEngine
{
    public static class ProductExtensions
    {
        internal static void ExecuteAction(this Product product, Action action)
        {
            switch (action.Type)
            {
                case ActionType.DiscountPercentage:
                    decimal percentage = decimal.Multiply(action.Value, 0.01M);
                    var discount = decimal.Multiply(product.Attributes["Price"], percentage);
                    product.Attributes["Price"] -= discount;
                    break;
                case ActionType.DiscountFixedAmount:
                    break;
                case ActionType.SetFixedPrice:
                    break;
            }
        }
    }
}
