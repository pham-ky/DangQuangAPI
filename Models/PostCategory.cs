using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class PostCategory
    {
        public PostCategory()
        {
            Post = new HashSet<Post>();
        }

        public Guid PostCategoryId { get; set; }
        public string PostCategoryName { get; set; }
        public string PostCategoryDescription { get; set; }
        public DateTime? PostCategoryCreatedAt { get; set; }
        public DateTime? PostCategoryUpdatedAt { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
