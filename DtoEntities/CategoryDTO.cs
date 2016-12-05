using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoEntities
{
    public class CategoryDTO
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
