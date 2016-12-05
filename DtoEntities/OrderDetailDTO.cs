using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoEntities
{
    public class OrderDetailDTO
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime Timestamp { get; set; }
        public long OrderId { get; set; }
    }
}
