using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Generic;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NewsUpdatesController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public NewsUpdatesController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]ewsUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsUpdate>>> GetNewsUpdates()
        {
          if (_context.NewsUpdates == null)
          {
              return NotFound();
          }
            return await _context.NewsUpdates.ToListAsync();
        }

        // GET: v1//[controller]ewsUpdates/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<NewsUpdate>> GetNewsUpdate(int id)
        {
          if (_context.NewsUpdates == null)
          {
              return NotFound();
          }
            var newsUpdate = await _context.NewsUpdates.FindAsync(id);

            if (newsUpdate == null)
            {
                return NotFound();
            }

            return newsUpdate;
        }

        // PUT: v1//[controller]ewsUpdates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutNewsUpdate(int id, NewsUpdate newsUpdate)
        {
            if (id != newsUpdate.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsUpdateExists(id))
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

        // POST: v1//[controller]ewsUpdates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsUpdate>> PostNewsUpdate(NewsUpdate newsUpdate)
        {
          if (_context.NewsUpdates == null)
          {
              return Problem("Entity set 'DefaultDbContext.NewsUpdates'  is null.");
          }
            _context.NewsUpdates.Add(newsUpdate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsUpdate", new { id = newsUpdate.Id }, newsUpdate);
        }

        // DELETE: v1//[controller]ewsUpdates/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNewsUpdate(int id)
        {
            if (_context.NewsUpdates == null)
            {
                return NotFound();
            }
            var newsUpdate = await _context.NewsUpdates.FindAsync(id);
            if (newsUpdate == null)
            {
                return NotFound();
            }

            _context.NewsUpdates.Remove(newsUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsUpdateExists(int id)
        {
            return (_context.NewsUpdates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




