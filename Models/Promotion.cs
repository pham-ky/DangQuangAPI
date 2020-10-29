using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Promotion
    {
        public Guid PromotionId { get; set; }
        public Guid? PromotionProductId { get; set; }
        public int? PromotionPromotion { get; set; }
        public DateTime? PromotionStartDay { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public DateTime? PromotionCreatedAt { get; set; }
        public DateTime? PromotionUpdatedAt { get; set; }

        public virtual Product PromotionProduct { get; set; }
    }
}
