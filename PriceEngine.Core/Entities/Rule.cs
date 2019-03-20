using PriceEngine.Core.Entities;
using System.Collections.Generic;

namespace PriceEngine.Core
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string Name { get; set; }
        public int  Priority { get; set; }
        public List<int> CustomerSegmentIds { get; set; }
        public List<int> ShopIds { get; set; }
        public bool ContinueProcessing { get; set; }
        public ConditionsContainer Condition { get; set; }
        public Action Action { get; set; }
    }
}
