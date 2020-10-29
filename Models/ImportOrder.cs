using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class ImportOrder
    {
        public Guid ImportOrderId { get; set; }
        public Guid? ImportOrderUserId { get; set; }
        public string ImportOrderNameOfConsignee { get; set; }
        public Guid? ImportOrderSupplierId { get; set; }
        public long? ImportOrderTotalPrice { get; set; }
        public DateTime? ImportOrderCreatedAt { get; set; }

        public virtual User ImportOrderUser { get; set; }
    }
}
