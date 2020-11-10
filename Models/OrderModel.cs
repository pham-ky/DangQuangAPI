using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DangQuangAPI.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderUserId { get; set; }
        public string OrderNameOfConsignee { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string OrderNote { get; set; }
        public long? OrderTotalPrice { get; set; }
        public int? OrderStatus { get; set; }
        public DateTime? OrderCreatedAt { get; set; }
        public DateTime? OrderUpdatedAt { get; set; }
        public string OrderDetails { get; set; }
    }
}
