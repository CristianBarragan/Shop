using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModelEntities
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public DateTime Timestamp { get; set; }
        public List<OrderDetail> details { get; set; }
    }
}
