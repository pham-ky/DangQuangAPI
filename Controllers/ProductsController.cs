using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DangQuangAPI.Models;
using System.Net.Http;
using System.Net;

namespace DangQuangAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly glasseyeContext _context;

        public ProductsController(glasseyeContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/5
        [HttpPost]
        public ResponseModel GetProducts([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();

            var page = int.Parse(formData["page"].ToString());
            var pageSize = int.Parse(formData["pageSize"].ToString());
            var result = formData["item_group_id"].ToString();
            List<Product> prod = null;
            if (result == "all")
            {
                //prod = _context.Product.ToList();
                
                int _skip = (page - 1) * pageSize;
                response.TotalItems = _context.Product.Count();

                prod = _context.Product.Skip(_skip).Take(pageSize).ToList();
                //hello
                response.Data = prod;
                response.Page = page;
                response.PageSize = pageSize;
                return response;
            }
            if (_context.Product.Where(x => x.ProductProductCategoryId.Value == Guid.Parse(result)).Count() > 0)
            {
                //prod = _context.Product
                //    .Where(x => x.ProductProductCategoryId.Value == Guid.Parse(result))
                //    .ToList();

                int _skip = (page - 1) * pageSize;
                response.TotalItems = _context.Product
                    .Where(x => x.ProductProductCategoryId.Value == Guid.Parse(result)).Count();

                prod = _context.Product
                    .Where(x => x.ProductProductCategoryId.Value == Guid.Parse(result))
                    .Skip(_skip).Take(pageSize).ToList();

                response.Data = prod;
                response.Page = page;
                response.PageSize = pageSize;
                return response;
            }
            if (_context.Product.Where(x => x.ProductSupplierId.Value == Guid.Parse(result)).Count() > 0)
            {
                //prod = _context.Product
                //    .Where(x => x.ProductSupplierId.Value == Guid.Parse(result))
                //    .ToList();
                
                int _skip = (page - 1) * pageSize;
                response.TotalItems = _context.Product
                    .Where(x => x.ProductSupplierId.Value == Guid.Parse(result)).Count();

                prod = _context.Product
                    .Where(x => x.ProductSupplierId.Value == Guid.Parse(result))
                    .Skip(_skip).Take(pageSize).ToList();

                response.Data = prod;
                response.Page = page;
                response.PageSize = pageSize;
                return response;
            }
            //if (_context.Product.Where(x => x.ProductName.ToLower().Contains(result.ToLower())) != null)
            //    prod = _context.Product.Where(x => x.ProductName.ToLower().Contains(result.ToLower()));

            return null;
        }


        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(Guid id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
