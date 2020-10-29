using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DangQuangAPI.Models
{
    public partial class glasseyeContext : DbContext
    {
        public glasseyeContext()
        {
        }

        public glasseyeContext(DbContextOptions<glasseyeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ImportOrder> ImportOrder { get; set; }
        public virtual DbSet<ImportOrderDetail> ImportOrderDetail { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostCategory> PostCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=glasseye;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommentContent)
                    .HasColumnName("comment_content")
                    .HasColumnType("ntext");

                entity.Property(e => e.CommentCreatedAt)
                    .HasColumnName("comment_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CommentProductId).HasColumnName("comment_product_id");

                entity.Property(e => e.CommentUserId).HasColumnName("comment_user_id");

                entity.HasOne(d => d.CommentProduct)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CommentProductId)
                    .HasConstraintName("FK_comment_product");

                entity.HasOne(d => d.CommentUser)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CommentUserId)
                    .HasConstraintName("FK_comment_user");
            });

            modelBuilder.Entity<ImportOrder>(entity =>
            {
                entity.ToTable("import_order");

                entity.Property(e => e.ImportOrderId)
                    .HasColumnName("import_order_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImportOrderCreatedAt)
                    .HasColumnName("import_order_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImportOrderNameOfConsignee)
                    .HasColumnName("import_order_name_of_consignee")
                    .HasMaxLength(150);

                entity.Property(e => e.ImportOrderSupplierId).HasColumnName("import_order_supplier_id");

                entity.Property(e => e.ImportOrderTotalPrice).HasColumnName("import_order_total_price");

                entity.Property(e => e.ImportOrderUserId).HasColumnName("import_order_user_id");

                entity.HasOne(d => d.ImportOrderUser)
                    .WithMany(p => p.ImportOrder)
                    .HasForeignKey(d => d.ImportOrderUserId)
                    .HasConstraintName("FK_import_order_user");
            });

            modelBuilder.Entity<ImportOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("import_order_detail");

                entity.Property(e => e.ImportOrderDetailImportOrderId).HasColumnName("import_order_detail_import_order_id");

                entity.Property(e => e.ImportOrderDetailPrice).HasColumnName("import_order_detail_price");

                entity.Property(e => e.ImportOrderDetailProductId).HasColumnName("import_order_detail_product_id");

                entity.Property(e => e.ImportOrderDetailProductName)
                    .HasColumnName("import_order_detail_product_name")
                    .HasMaxLength(150);

                entity.Property(e => e.ImportOrderDetailQuantity).HasColumnName("import_order_detail_quantity");

                entity.HasOne(d => d.ImportOrderDetailImportOrder)
                    .WithMany()
                    .HasForeignKey(d => d.ImportOrderDetailImportOrderId)
                    .HasConstraintName("FK_import_order_detail_import_order");

                entity.HasOne(d => d.ImportOrderDetailProduct)
                    .WithMany()
                    .HasForeignKey(d => d.ImportOrderDetailProductId)
                    .HasConstraintName("FK_import_order_detail_product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderAddress)
                    .HasColumnName("order_address")
                    .HasMaxLength(150);

                entity.Property(e => e.OrderCreatedAt)
                    .HasColumnName("order_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderNameOfConsignee)
                    .HasColumnName("order_name_of_consignee")
                    .HasMaxLength(150);

                entity.Property(e => e.OrderNote)
                    .HasColumnName("order_note")
                    .HasColumnType("ntext");

                entity.Property(e => e.OrderPhone)
                    .HasColumnName("order_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.OrderTotalPrice).HasColumnName("order_total_price");

                entity.Property(e => e.OrderUpdatedAt)
                    .HasColumnName("order_updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderUserId).HasColumnName("order_user_id");

                entity.HasOne(d => d.OrderUser)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderUserId)
                    .HasConstraintName("FK_order_user");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_detail");

                entity.Property(e => e.OrderDetailOrderId).HasColumnName("order_detail_order_id");

                entity.Property(e => e.OrderDetailPrice).HasColumnName("order_detail_price");

                entity.Property(e => e.OrderDetailProductId).HasColumnName("order_detail_product_id");

                entity.Property(e => e.OrderDetailQuantity).HasColumnName("order_detail_quantity");

                entity.HasOne(d => d.OrderDetailOrder)
                    .WithMany()
                    .HasForeignKey(d => d.OrderDetailOrderId)
                    .HasConstraintName("FK_order_detail_order");

                entity.HasOne(d => d.OrderDetailProduct)
                    .WithMany()
                    .HasForeignKey(d => d.OrderDetailProductId)
                    .HasConstraintName("FK_order_detail_product");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PostContent)
                    .HasColumnName("post_content")
                    .HasColumnType("ntext");

                entity.Property(e => e.PostCreatedAt)
                    .HasColumnName("post_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostName)
                    .HasColumnName("post_name")
                    .HasMaxLength(150);

                entity.Property(e => e.PostPostCategoryId).HasColumnName("post_post_category_id");

                entity.Property(e => e.PostShowonhome).HasColumnName("post_showonhome");

                entity.Property(e => e.PostUpdatedAt)
                    .HasColumnName("post_updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.PostPostCategory)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.PostPostCategoryId)
                    .HasConstraintName("FK_post_post_category");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.ToTable("post_category");

                entity.Property(e => e.PostCategoryId)
                    .HasColumnName("post_category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PostCategoryCreatedAt)
                    .HasColumnName("post_category_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostCategoryDescription)
                    .HasColumnName("post_category_description")
                    .HasMaxLength(150);

                entity.Property(e => e.PostCategoryName)
                    .HasColumnName("post_category_name")
                    .HasMaxLength(150);

                entity.Property(e => e.PostCategoryUpdatedAt)
                    .HasColumnName("post_category_updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductCreatedAt)
                    .HasColumnName("product_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasColumnType("ntext");

                entity.Property(e => e.ProductEyeColor)
                    .HasColumnName("product_eye_color")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductEyeglassWidth)
                    .HasColumnName("product_eyeglass_width")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductFrameLength)
                    .HasColumnName("product_frame_length")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductFrameMaterial)
                    .HasColumnName("product_frame_material")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("product_image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImportPrice).HasColumnName("product_import_price");

                entity.Property(e => e.ProductMoreImage)
                    .HasColumnName("product_more_image")
                    .HasColumnType("xml");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductNoseWidth)
                    .HasColumnName("product_nose_width")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductProductCategoryId).HasColumnName("product_product_category_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.ProductSex).HasColumnName("product_sex");

                entity.Property(e => e.ProductShowonhome).HasColumnName("product_showonhome");

                entity.Property(e => e.ProductStatus).HasColumnName("product_status");

                entity.Property(e => e.ProductSupplierId).HasColumnName("product_supplier_id");

                entity.Property(e => e.ProductUpdatedAt)
                    .HasColumnName("product_updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ProductProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductProductCategoryId)
                    .HasConstraintName("FK_product_product_category");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .HasConstraintName("FK_product_supplier");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("product_category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductCategoryCreatedAt)
                    .HasColumnName("product_category_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductCategoryDescription)
                    .HasColumnName("product_category_description")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductCategoryName)
                    .HasColumnName("product_category_name")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductCategoryShowonhome).HasColumnName("product_category_showonhome");

                entity.Property(e => e.ProductCategoryUpdatedAt)
                    .HasColumnName("product_category_updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotion");

                entity.Property(e => e.PromotionId)
                    .HasColumnName("promotion_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PromotionCreatedAt)
                    .HasColumnName("promotion_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PromotionEndDate)
                    .HasColumnName("promotion_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.PromotionProductId).HasColumnName("promotion_product_id");

                entity.Property(e => e.PromotionPromotion).HasColumnName("promotion_promotion");

                entity.Property(e => e.PromotionStartDay)
                    .HasColumnName("promotion_start_day")
                    .HasColumnType("date");

                entity.Property(e => e.PromotionUpdatedAt)
                    .HasColumnName("promotion_updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.PromotionProduct)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.PromotionProductId)
                    .HasConstraintName("FK_promotion_product");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("slide");

                entity.Property(e => e.SlideId)
                    .HasColumnName("slide_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SlideImage)
                    .HasColumnName("slide_image")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SupplierAddress)
                    .HasColumnName("supplier_address")
                    .HasMaxLength(150);

                entity.Property(e => e.SupplierCreatedAt)
                    .HasColumnName("supplier_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierEmail)
                    .HasColumnName("supplier_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasColumnName("supplier_name")
                    .HasMaxLength(150);

                entity.Property(e => e.SupplierPhone)
                    .HasColumnName("supplier_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierUpdatedAt)
                    .HasColumnName("supplier_updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserAddress)
                    .HasColumnName("user_address")
                    .HasMaxLength(150);

                entity.Property(e => e.UserCreatedAt)
                    .HasColumnName("user_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullName)
                    .HasColumnName("user_full_name")
                    .HasMaxLength(75);

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("user_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("user_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus).HasColumnName("user_status");

                entity.Property(e => e.UserUpdatedAt)
                    .HasColumnName("user_updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("wishlist");

                entity.Property(e => e.WishlistId)
                    .HasColumnName("wishlist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.WishlistCreatedAt)
                    .HasColumnName("wishlist_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.WishlistProductId).HasColumnName("wishlist_product_id");

                entity.Property(e => e.WishlistUserId).HasColumnName("wishlist_user_id");

                entity.HasOne(d => d.WishlistProduct)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.WishlistProductId)
                    .HasConstraintName("FK_wishlist_product");

                entity.HasOne(d => d.WishlistUser)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.WishlistUserId)
                    .HasConstraintName("FK_wishlist_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
