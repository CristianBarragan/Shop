using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoEntities
{
    public class OrderDTO
    {
        public long OrderId { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
