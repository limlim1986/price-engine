using PriceEngine.Core;

namespace PriceEngine
{
    public interface IRuleGenerator
    {
        Rule GetRandomRule(int id, int prio);
    }
}