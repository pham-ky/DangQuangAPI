using System;
using System.Collections.Generic;

namespace DangQuangAPI.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            ImportOrder = new HashSet<ImportOrder>();
            Order = new HashSet<Order>();
            Wishlist = new HashSet<Wishlist>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserFullName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int? UserStatus { get; set; }
        public DateTime? UserCreatedAt { get; set; }
        public DateTime? UserUpdatedAt { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Comment> Comment { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<ImportOrder> ImportOrder { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Order> Order { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
