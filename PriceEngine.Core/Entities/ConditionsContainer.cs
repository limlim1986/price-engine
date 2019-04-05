using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine.Core.Entities
{
    public class ConditionsContainer
    {
        private readonly List<Condition> conditions;
        private readonly List<ConditionsContainer> conditionContainers;
        private readonly ConditionContainerType type;

        public ConditionsContainer(ConditionContainerType type, List<Condition> conditions)
        {
            this.type = type;
            this.conditions = conditions ?? throw new ArgumentNullException(nameof(conditions));
            this.conditionContainers = new List<ConditionsContainer>();
        }

        public ConditionsContainer(ConditionContainerType type, List<ConditionsContainer> conditionContainers)
        {
            if(conditionContainers == null)
                throw new ArgumentNullException(nameof(conditionContainers));

            if (conditionContainers.Count < 2)
                throw new ArgumentException("provide at least 2 condition containers or use simple conditions instead");

            this.type = type;
            this.conditionContainers = conditionContainers;
            this.conditions = new List<Condition>();
        }

        public bool ConditionsApplyTo(Product product)
        {      
            if (conditions.Any())
            {
                return type == ConditionContainerType.All ? conditions.All(c => c.Check(product)) : conditions.Any(c => c.Check(product));
            }

            return type == ConditionContainerType.All ? conditionContainers.All(cc => cc.ConditionsApplyTo(product)) : conditionContainers.Any(cc => cc.ConditionsApplyTo(product));
        }
    }
}
