using System;
using System.Collections.Generic;

namespace PriceEngine.Core.Entities
{
    public class ConditionsContainer
    {
        public ConditionsContainer(ConditionContainerType type, List<Condition> conditions)
        {
            Type = type;
            Conditions = conditions ?? throw new ArgumentNullException(nameof(conditions));
            ConditionContainers = new List<ConditionsContainer>();
        }

        public ConditionsContainer(ConditionContainerType type, List<ConditionsContainer> conditionContainers)
        {
            if(conditionContainers == null)
                throw new ArgumentNullException(nameof(conditionContainers));

            if (conditionContainers.Count < 2)
                throw new ArgumentException("provide at least 2 condition containers or use simple conditions instead");

            Type = type;
            ConditionContainers = conditionContainers;
            Conditions = new List<Condition>();
        }

        public ConditionContainerType Type { get; private set; }
        public List<Condition> Conditions { get; private set; }
        public List<ConditionsContainer> ConditionContainers { get; private set; }


        public bool Check(Product product)
        {
            return CheckContainer(product);
        }

        private bool CheckContainer(Product p)
        {
            // if conditions exist we simply check them and return
            if (Conditions.Count > 0)
            {
                // else we have containers and need to run the recursive check
                if (Type == ConditionContainerType.All)
                {
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        bool cm = Conditions[i].Check(p);
                        if (!cm)
                            return false;
                    }
                }
                else
                {
                    for (int i = 0; i < Conditions.Count; i++)
                    {
                        bool cm = Conditions[i].Check(p);
                        if (cm)
                            return true;
                    }
                }
            }

            // Check conditions in nested containers recursivley
            for (int i = 0; i < ConditionContainers.Count; i++)
            {
                var cc = ConditionContainers[i];
                bool conditionsMet = cc.CheckContainer(p);

                if (cc.Type == ConditionContainerType.All)
                {
                    if (!conditionsMet)
                        return false;
                }
                else
                {
                    if (conditionsMet)
                        return true;
                }
            }


            return true;
        }
    }
}
