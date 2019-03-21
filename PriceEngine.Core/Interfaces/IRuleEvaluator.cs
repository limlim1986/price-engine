using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IRuleEvaluator
    {
        Product ApplyRules(Rule[] rules, Product product);
    }
}