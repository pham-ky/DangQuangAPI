using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }
        public DateTime? SupplierCreatedAt { get; set; }
        public DateTime? SupplierUpdatedAt { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
