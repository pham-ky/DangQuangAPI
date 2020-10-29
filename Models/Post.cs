using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class Post
    {
        public Guid PostId { get; set; }
        public string PostName { get; set; }
        public Guid? PostPostCategoryId { get; set; }
        public string PostContent { get; set; }
        public bool? PostShowonhome { get; set; }
        public DateTime? PostCreatedAt { get; set; }
        public DateTime? PostUpdatedAt { get; set; }

        public virtual PostCategory PostPostCategory { get; set; }
    }
}
