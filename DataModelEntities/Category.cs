using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModelEntities
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Product> Products { get; set; }
    }
}
