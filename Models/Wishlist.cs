using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Wishlist
    {
        public Guid WishlistId { get; set; }
        public Guid? WishlistUserId { get; set; }
        public Guid? WishlistProductId { get; set; }
        public DateTime? WishlistCreatedAt { get; set; }

        public virtual Product WishlistProduct { get; set; }
        public virtual User WishlistUser { get; set; }
    }
}
