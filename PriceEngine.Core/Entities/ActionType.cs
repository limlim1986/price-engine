using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PriceEngine.Core.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType
    {
        DiscountPercentage,
        DiscountFixedAmount,
        SetFixedPrice
    }
}
