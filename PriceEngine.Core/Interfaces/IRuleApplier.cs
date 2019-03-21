using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IRuleApplier
    {
        Product[] ApplyRules(Rule[] rules, Product[] products);
    }
}