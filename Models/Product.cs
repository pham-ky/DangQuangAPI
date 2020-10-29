using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Comment = new HashSet<Comment>();
            Promotion = new HashSet<Promotion>();
            Wishlist = new HashSet<Wishlist>();
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid? ProductSupplierId { get; set; }
        public Guid? ProductProductCategoryId { get; set; }
        public int? ProductSex { get; set; }
        public string ProductEyeColor { get; set; }
        public string ProductFrameMaterial { get; set; }
        public decimal? ProductEyeglassWidth { get; set; }
        public decimal? ProductNoseWidth { get; set; }
        public decimal? ProductFrameLength { get; set; }
        public long? ProductImportPrice { get; set; }
        public long? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public string ProductImage { get; set; }
        public string ProductMoreImage { get; set; }
        public string ProductDescription { get; set; }
        public bool? ProductStatus { get; set; }
        public bool? ProductShowonhome { get; set; }
        public DateTime? ProductCreatedAt { get; set; }
        public DateTime? ProductUpdatedAt { get; set; }

        public virtual ProductCategory ProductProductCategory { get; set; }
        public virtual Supplier ProductSupplier { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Promotion> Promotion { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
