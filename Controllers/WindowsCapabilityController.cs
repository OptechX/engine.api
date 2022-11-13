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
    public class WindowsCapabilityController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WindowsCapabilityController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WindowsCapability
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilities()
        {
          if (_context.WindowsCapabilities == null)
          {
              return NotFound();
          }
            return await _context.WindowsCapabilities.ToListAsync();
        }

        // GET: v1WindowsCapability/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WindowsCapability>> GetWindowsCapability(int id)
        {
          if (_context.WindowsCapabilities == null)
          {
              return NotFound();
          }
            var windowsCapability = await _context.WindowsCapabilities.FindAsync(id);

            if (windowsCapability == null)
            {
                return NotFound();
            }

            return windowsCapability;
        }

        // PUT: v1WindowsCapability/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWindowsCapability(int id, WindowsCapability windowsCapability)
        {
            if (id != windowsCapability.Id)
            {
                return BadRequest();
            }

            _context.Entry(windowsCapability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WindowsCapabilityExists(id))
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

        // POST: v1WindowsCapability
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WindowsCapability>> PostWindowsCapability(WindowsCapability windowsCapability)
        {
          if (_context.WindowsCapabilities == null)
          {
              return Problem("Entity set 'DefaultDbContext.WindowsCapabilities'  is null.");
          }
            _context.WindowsCapabilities.Add(windowsCapability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindowsCapability", new { id = windowsCapability.Id }, windowsCapability);
        }

        // DELETE: v1WindowsCapability/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWindowsCapability(int id)
        {
            if (_context.WindowsCapabilities == null)
            {
                return NotFound();
            }
            var windowsCapability = await _context.WindowsCapabilities.FindAsync(id);
            if (windowsCapability == null)
            {
                return NotFound();
            }

            _context.WindowsCapabilities.Remove(windowsCapability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WindowsCapabilityExists(int id)
        {
            return (_context.WindowsCapabilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

