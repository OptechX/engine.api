using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;

namespace api.engine_v2.Controllers
{
    [Route("v1[controller]")]
    [ApiController]
    public class WindowsCoreIdentityController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WindowsCoreIdentityController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WindowsCoreIdentity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentities()
        {
          if (_context.WindowsCoreIdentities == null)
          {
              return NotFound();
          }
            return await _context.WindowsCoreIdentities.ToListAsync();
        }

        // GET: v1WindowsCoreIdentity/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WindowsCoreIdentity>> GetWindowsCoreIdentity(int id)
        {
          if (_context.WindowsCoreIdentities == null)
          {
              return NotFound();
          }
            var windowsCoreIdentity = await _context.WindowsCoreIdentities.FindAsync(id);

            if (windowsCoreIdentity == null)
            {
                return NotFound();
            }

            return windowsCoreIdentity;
        }

        // PUT: v1WindowsCoreIdentity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWindowsCoreIdentity(int id, WindowsCoreIdentity windowsCoreIdentity)
        {
            if (id != windowsCoreIdentity.Id)
            {
                return BadRequest();
            }

            _context.Entry(windowsCoreIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WindowsCoreIdentityExists(id))
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

        // POST: v1WindowsCoreIdentity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WindowsCoreIdentity>> PostWindowsCoreIdentity(WindowsCoreIdentity windowsCoreIdentity)
        {
          if (_context.WindowsCoreIdentities == null)
          {
              return Problem("Entity set 'DefaultDbContext.WindowsCoreIdentities'  is null.");
          }
            _context.WindowsCoreIdentities.Add(windowsCoreIdentity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindowsCoreIdentity", new { id = windowsCoreIdentity.Id }, windowsCoreIdentity);
        }

        // DELETE: v1WindowsCoreIdentity/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWindowsCoreIdentity(int id)
        {
            if (_context.WindowsCoreIdentities == null)
            {
                return NotFound();
            }
            var windowsCoreIdentity = await _context.WindowsCoreIdentities.FindAsync(id);
            if (windowsCoreIdentity == null)
            {
                return NotFound();
            }

            _context.WindowsCoreIdentities.Remove(windowsCoreIdentity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WindowsCoreIdentityExists(int id)
        {
            return (_context.WindowsCoreIdentities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


