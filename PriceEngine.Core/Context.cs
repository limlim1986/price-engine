using System.Collections.Generic;

namespace PriceEngine
{
    public class Context
    {
        public List<int> CustomerSegmentIds { get; set; }
        public int ShopId { get; set; }
        public Customer Customer { get; set; }
    }
}
