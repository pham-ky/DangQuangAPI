using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DangQuangAPI.Models
{
    public class OrderdetailModel
    {
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public long productPrice { get; set; }
    }
}
