using Newtonsoft.Json;
using PriceEngine.Core;
using PriceEngine.Core.Entities;
using PriceEngine.Core.Operators;
using System;
using System.Collections.Generic;
using Action = PriceEngine.Core.Entities.Action;

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
                var prio = random.Next(20, 100);

                var r = new Rule
                {
                    RuleId = i,
                    Name = "10% off for all products that cost 10",
                    Action = new Action { Type = ActionType.DiscountFixedAmount, Value = 1},
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
                                Operator = OperatorConstant.Equals,
                                Value = "Red"
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = OperatorConstant.GreaterThan,
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = OperatorConstant.GreaterThan,
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = OperatorConstant.GreaterThan,
                                Value = 1M
                            },
                            new Condition
                            {
                                ContextPropertyName = "Price",
                                Operator = OperatorConstant.GreaterThan,
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
                                        Operator = OperatorConstant.Equals,
                                        Value = "Red"
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = OperatorConstant.GreaterThan,
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = OperatorConstant.GreaterThan,
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = OperatorConstant.GreaterThan,
                                        Value = 1M
                                    },
                                    new Condition
                                    {
                                        ContextPropertyName = "Price",
                                        Operator = OperatorConstant.GreaterThan,
                                        Value = 1M
                                    }
                                }
                            },
                        },
                    },
                };

                _rules.Add(r);
            }

            //var nr = new Rule
            //{
            //    Name = "color in red blue or black gives price of 1",
            //    ContinueProcessing = false,
            //    Priority = 1,
            //    RuleId = 999,
            //    ShopIds = new List<int> { 1 },
            //    CustomerSegmentIds = new List<int> { 1 },
            //    Action = new Action { Type = ActionType.SetFixedPrice, Value = 1 },
            //    Condition = new ConditionsContainer
            //    {
            //        Type = ConditionContainerType.All,
            //        Conditions = new List<Condition>
            //        {
            //            new Condition
            //            {
            //                ContextPropertyName = "Color",
            //                Operator = OperatorConstant.In,
            //                Value = "Red, Blue, Black"
            //            }
            //        }
            //    }
            //};

            //_rules.Add(nr);
        }

        public List<Rule> GetAll()
        {
            return _rules;
        }
    }
}