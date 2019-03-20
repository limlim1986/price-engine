using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PriceEngine.Core.Operators
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperatorConstant
    {
        Equals,
        GreaterThan,
        LessThan,
        In,
        NotIn
    }
}
