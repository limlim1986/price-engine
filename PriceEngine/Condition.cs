using System.Collections.Generic;

namespace PriceEngine
{
    public class ConditionsContainer
    {
        public ConditionContainerType Type { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<ConditionsContainer> ConditionContainers { get; set; }
    }


    public enum ConditionContainerType
    {
        All,
        Any
    }

    public class Condition
    {
        public string Operator { get; set; }
        public dynamic Value { get; set; }
        public string ContextPropertyName { get; internal set; }
    }
}
