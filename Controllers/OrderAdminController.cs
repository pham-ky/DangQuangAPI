using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DangQuangAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DangQuangAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderAdminController : ControllerBase
    {
        private readonly glasseyeContext _context;

        public OrderAdminController(glasseyeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Object Statistical()
        {
            int x = 0;
            int[] quantity = new int[6];
            long[] totalPrice = new long[6];
            double totalQuantity = 0;
            double totalQuantity2 = 0;
            double totalMoney = 0;
            double totalMoney2 = 0;

            double quantityOdr = _context.Order.Where(x => x.OrderCreatedAt.Month == DateTime.Now.AddMonths(+10).Month 
                                                        && x.OrderStatus == 4).Count();
            double quantityOdr2 = _context.Order.Where(x => x.OrderCreatedAt.Month == DateTime.Now.AddMonths(+9).Month
                                                        && x.OrderStatus == 4).Count();

            double percentOdr = Math.Round(((quantityOdr - quantityOdr2) / quantityOdr2) * 100, 2);

            var od = from r in _context.Order
                     where r.OrderCreatedAt.Month == DateTime.Now.AddMonths(+10).Month && r.OrderStatus == 4
                     join j in _context.OrderDetail on r.OrderId equals j.OrderDetailOrderId
                     select j;

            foreach (var odr in od)
            {
                totalQuantity += odr.OrderDetailQuantity;
                totalMoney += odr.OrderDetailQuantity * odr.OrderDetailPrice;
            }

            var od2 = from r in _context.Order
                      where r.OrderCreatedAt.Month == DateTime.Now.AddMonths(+9).Month && r.OrderStatus == 4
                      join j in _context.OrderDetail on r.OrderId equals j.OrderDetailOrderId
                      select j; ;

            foreach (var odr in od2)
            {
                totalQuantity2 += odr.OrderDetailQuantity;
                totalMoney2 += odr.OrderDetailQuantity * odr.OrderDetailPrice;
            }

            double percentQty = Math.Round(((totalQuantity - totalQuantity2) / totalQuantity2) * 100, 2);
            double percentMoney = Math.Round(((totalMoney - totalMoney2) / totalMoney2) * 100, 2);
            for (int i = 7; i > 1; i--)
            {
                long S = 0;
                var previousDate = DateTime.Now.AddMonths(-i);
                var p = _context.Order.Where(x => x.OrderCreatedAt.Month == previousDate.Month && x.OrderStatus == 4);
                quantity[x] = _context.Order.Where(x => x.OrderCreatedAt.Month == previousDate.Month && x.OrderStatus == 4).Count();
                foreach(var odr in p)
                {
                    S += odr.OrderTotalPrice;
                }
                totalPrice[x] = S;
                x++;
            }
            return new { quantity, totalPrice, totalQuantity, percentQty, quantityOdr, percentOdr, totalMoney, percentMoney};
        }
        // GET: api/<OrderAdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public ResponseModel GetOrders([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            var page = int.Parse(formData["page"].ToString());
            var pageSize = int.Parse(formData["pageSize"].ToString());
            var result = formData["item_group_id"].ToString();
            //List<Order> Odr = null;

            int _skip = (page - 1) * pageSize;
            response.TotalItems = _context.Order.Where(x => x.OrderStatus == int.Parse(result)).Count();
            response.Data = _context.Order.Where(x => x.OrderStatus == int.Parse(result)).Skip(_skip).Take(pageSize).ToList();
            response.Page = page;
            response.PageSize = pageSize;
            return response;
        }

        // POST api/<OrderAdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderAdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
