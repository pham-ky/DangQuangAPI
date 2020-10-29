using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DangQuangAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DangQuangAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly glasseyeContext _context;

        public OrdersController(glasseyeContext context)
        {
            _context = context;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<int> Add(Order orders)
        {
            Order order = new Order()
            {
                OrderId = Guid.NewGuid(),
                OrderUserId = Guid.NewGuid(),
                OrderNameOfConsignee = orders.OrderNameOfConsignee,
                OrderAddress = orders.OrderAddress,
                OrderPhone = orders.OrderPhone,
                OrderNote = orders.OrderNote,
                OrderTotalPrice = orders.OrderTotalPrice,
                OrderStatus = 1,
                OrderCreatedAt = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            };
            _context.Order.Add(order);
            var res = await _context.SaveChangesAsync();
            //var ods = JsonConvert.DeserializeObject<List<OrderDetail>>(orders.orderDetails);
            //foreach (var p in ods)
            //{
            //    OrderDetail od = new OrderDetail()
            //    {
            //        OrderDetailProductId = p.productId,
            //        OrderId = order.Id,
            //        Price = p.Price,
            //        Quantity = p.Quantity
            //    };
            //    _daxoneDBContext.OrderDetails.Add(od);
            //    await _daxoneDBContext.SaveChangesAsync();
            //}
            return res;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
