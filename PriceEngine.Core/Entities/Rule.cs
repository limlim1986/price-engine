using PriceEngine.Core.Entities;
using PriceEngine.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace PriceEngine.Core
{
    public class Rule
    {
        private readonly ConditionsContainer condition;
        private readonly IAction action;

        public Rule(ConditionsContainer condition, IAction action)
        {
            this.condition = condition;
            this.action = action;
        }

        public int RuleId { get; set; }
        public string Name { get; set; }
        public int  Priority { get; set; }
        public List<int> CustomerSegmentIds { get; set; }
        public List<int> ShopIds { get; set; }
        public bool ContinueProcessing { get; set; }
        public Entities.Action Action { get; set; }     

        public bool AppliesTo(Product product)
        {
            return condition.ConditionsApplyTo(product);
        }

        public void ExecuteAction(Product product)
        {
            action.Execute(product, Action.Value);
        }
    }
}
