using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public bool? ProductCategoryShowonhome { get; set; }
        public DateTime? ProductCategoryCreatedAt { get; set; }
        public DateTime? ProductCategoryUpdatedAt { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
