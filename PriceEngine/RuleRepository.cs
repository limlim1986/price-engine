using System;
using System.Collections.Generic;

namespace PriceEngine
{
    public class RuleRepository
    {
        private List<Rule> _rules;

        public RuleRepository()
        {
            _rules = new List<Rule>();
            var random = new Random();

            for (int i = 1; i < 100; i++)
            {
                var prio = random.Next(1, 100);

                var r = new Rule
                {
                    RuleId = i,
                    Name = "10% off for all products that cost 10",
                    Action = new Action { Type = ActionType.DiscountPercentage, Value = 10},
                    ContinueProcessing = true,
                    Priority = prio,
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
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = "GratherThanOrEqualTo",
                                Value = 1M
                            }                     
                        },
                        ConditionContainers = new List<ConditionsContainer>
                        {
                            new ConditionsContainer
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
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    }
                                }
                            },
                            new ConditionsContainer
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
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    }
                                }
                            },
                            new ConditionsContainer
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
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = "GratherThanOrEqualTo",
                                        Value = 1M
                                    }
                                }
                            }
                        },
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