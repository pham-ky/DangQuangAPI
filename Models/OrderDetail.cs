using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class OrderDetail
    {
        public Guid OrderDetailOrderId { get; set; }
        public Guid OrderDetailProductId { get; set; }
        public int? OrderDetailQuantity { get; set; }
        public long? OrderDetailPrice { get; set; }

        public virtual Order OrderDetailOrder { get; set; }
        public virtual Product OrderDetailProduct { get; set; }
    }
}
