using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModelEntities
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
