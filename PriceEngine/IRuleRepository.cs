using System.Collections.Generic;
using PriceEngine.Core;

namespace PriceEngine
{
    public interface IRuleRepository
    {
        List<Rule> GetAll();
    }
}