using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class ImportOrderDetail
    {
        public Guid? ImportOrderDetailImportOrderId { get; set; }
        public Guid? ImportOrderDetailProductId { get; set; }
        public string ImportOrderDetailProductName { get; set; }
        public int? ImportOrderDetailQuantity { get; set; }
        public long? ImportOrderDetailPrice { get; set; }

        public virtual ImportOrder ImportOrderDetailImportOrder { get; set; }
        public virtual Product ImportOrderDetailProduct { get; set; }
    }
}
