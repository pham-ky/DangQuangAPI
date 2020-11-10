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
        //public async Task<IActionResult> AddOrder([FromBody] Order oders)
        //{
        //    var res = await Add(oders);
        //    if (res == 0)
        //        return BadRequest();
        //    return Ok(res);
        //}
        public async Task<int> Add(OrderModel orders)
        {
            var ID = Guid.NewGuid();
            Order order = new Order()
            {
                OrderId = ID,
                OrderUserId = orders.OrderUserId,
                OrderNameOfConsignee = orders.OrderNameOfConsignee,
                OrderAddress = orders.OrderAddress,
                OrderPhone = orders.OrderPhone,
                OrderNote = (orders.OrderNote!=null)? orders.OrderNote:"",
                OrderTotalPrice = orders.OrderTotalPrice,
                OrderStatus = 1,
                OrderCreatedAt = DateTime.Now
            };
            _context.Order.Add(order);
            int res;
            try
            {
                 res= await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var ods = JsonConvert.DeserializeObject<List<OrderdetailModel>>(orders.OrderDetails);
            foreach (var p in ods)
            {
                OrderDetail od = new OrderDetail()
                {
                    OrderDetailOrderId = order.OrderId,
                    OrderDetailProductId = p.productId,
                    OrderDetailPrice = p.productPrice,
                    OrderDetailQuantity = p.quantity
                };
                try
                {
                    _context.OrderDetail.Add(od);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
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
