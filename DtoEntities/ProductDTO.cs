using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoEntities
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
