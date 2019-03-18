using System.Collections.Generic;

namespace PriceEngine.Core
{
    public class Context
    {
        public List<int> CustomerSegmentIds { get; set; }
        public int ShopId { get; set; }
        public Customer Customer { get; set; }
    }
}
