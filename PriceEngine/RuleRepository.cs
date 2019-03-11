using System.Collections.Generic;

namespace PriceEngine
{
    public class RuleRepository
    {
        private List<Rule> _rules;

        public RuleRepository()
        {
            _rules = new List<Rule>();

            for(int i = 1; i < 1000; i++)
            {
                var r = new Rule
                {
                    RuleId = i,
                    Name = "10% off for all products that cost 10",
                    Condition = new ConditionsContainer
                    {
                        Type = ConditionContainerType.All,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                ContextPropertyName = "Color",
                                Operator = "Equals",
                                Value = "Red"
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 100M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 100M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 100M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 100M
                            }
                        }
                    },
                };

                _rules.Add(r);
            }           
        }

        public List<Rule> GetAll()
        {
            return _rules;
        }
    }
}