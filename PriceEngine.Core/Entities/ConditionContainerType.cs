using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PriceEngine.Core.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConditionContainerType
    {
        All,
        Any
    }
}
