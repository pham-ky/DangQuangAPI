using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DangQuangAPI.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DangQuangAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private readonly glasseyeContext _context;

        public UserAdminController(glasseyeContext context)
        {
            _context = context;
        }
        // GET: api/<UserAdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var us = user = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword && u.UserStatus == 1);
            return Ok(us);
        }

        // POST api/<UserAdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
