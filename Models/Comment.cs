using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Comment
    {
        public Guid CommentId { get; set; }
        public Guid? CommentUserId { get; set; }
        public Guid? CommentProductId { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CommentCreatedAt { get; set; }

        public virtual Product CommentProduct { get; set; }
        public virtual User CommentUser { get; set; }
    }
}
