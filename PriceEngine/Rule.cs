using System.Collections.Generic;

namespace PriceEngine
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string Name { get; set; }
        public int  Priority { get; set; }
        public List<string> CustomerSegments { get; set; }
        public List<int> ShopIds { get; set; }
        public bool ContinueProcessing { get; set; }
        public ConditionsContainer Condition { get; set; }
        public ActionType Action { get; set; }
    }
}
