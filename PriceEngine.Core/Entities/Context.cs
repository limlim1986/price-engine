using System.Collections.Generic;

namespace PriceEngine.Core.Entities
{
    public class Context
    {
        public List<int> CustomerSegmentIds { get; set; }
        public int ShopId { get; set; }
        public Customer Customer { get; set; }
    }
}
