﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModelEntities
{
    public class Promotion
    {
        public long PromotionId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
