using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DangQuangAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace DangQuangAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly glasseyeContext _context;

        public SlidesController(glasseyeContext context)
        {
            _context = context;
        }

        // GET: api/Slides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slide>>> GetSlide()
        {
            return await _context.Slide.ToListAsync();
        }

        // GET: api/Slides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slide>> GetSlide(Guid id)
        {
            var slide = await _context.Slide.FindAsync(id);

            if (slide == null)
            {
                return NotFound();
            }

            return slide;
        }

        // PUT: api/Slides/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlide(Guid id, Slide slide)
        {
            if (id != slide.SlideId)
            {
                return BadRequest();
            }

            _context.Entry(slide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlideExists(id))
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

        // POST: api/Slides
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Slide>> PostSlide(Slide slide)
        {
            _context.Slide.Add(slide);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SlideExists(slide.SlideId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSlide", new { id = slide.SlideId }, slide);
        }

        // DELETE: api/Slides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Slide>> DeleteSlide(Guid id)
        {
            var slide = await _context.Slide.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }

            _context.Slide.Remove(slide);
            await _context.SaveChangesAsync();

            return slide;
        }

        private bool SlideExists(Guid id)
        {
            return _context.Slide.Any(e => e.SlideId == id);
        }
    }
}
