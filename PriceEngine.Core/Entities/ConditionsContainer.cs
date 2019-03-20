using System.Collections.Generic;

namespace PriceEngine.Core.Entities
{
    public class ConditionsContainer
    {
        public ConditionContainerType Type { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<ConditionsContainer> ConditionContainers { get; set; }
    }
}
