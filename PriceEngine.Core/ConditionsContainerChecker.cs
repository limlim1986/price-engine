using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System.Linq;

namespace PriceEngine.Core
{
    public class ConditionsContainerChecker : IConditionsContainerChecker
    {
        private readonly ConditionChecker _conditionChecker;

        public ConditionsContainerChecker()
        {
            _conditionChecker = new ConditionChecker();
        }

        public bool Check(Rule rule, Product product)
        {
            return CheckContainer(rule.Condition, product);
        }

        private bool CheckContainer(ConditionsContainer container, Product p)
        {
            bool conditionsMet = false;
            if(container.Type == ConditionContainerType.All)
            {
                for(int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = _conditionChecker.Check(container.Conditions[i], p);
                    if (!cm)
                        return false;
                }
            }
            else
            {
                for (int i = 0; i < container.Conditions.Count; i++)
                {
                    bool cm = _conditionChecker.Check(container.Conditions[i], p);
                    if (cm)
                        return true;
                }
            }

            
            // Check conditions in nested containers recursivley
            if (container.ConditionContainers != null && container.ConditionContainers.Any())
            {
                for (int i = 0; i < container.ConditionContainers.Count; i++)
                {
                    ConditionsContainer cc = container.ConditionContainers[i];
                    conditionsMet = CheckContainer(cc, p);

                    if(cc.Type == ConditionContainerType.All)
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
            }

            return true;
        }
    }
}