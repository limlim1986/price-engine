﻿namespace PriceEngine
{
    public class AppliedRule
    {
        public Rule Rule { get; set; }
        public decimal PriceBeforeRuleWasApplied { get; set; }
        public decimal PriceAfterRuleWasApplied { get; set; }
    }
}