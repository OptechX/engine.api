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
    public class WindowsOptionalFeatureController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WindowsOptionalFeatureController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WindowsOptionalFeature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatures()
        {
          if (_context.WindowsOptionalFeatures == null)
          {
              return NotFound();
          }
            return await _context.WindowsOptionalFeatures.ToListAsync();
        }

        // GET: v1WindowsOptionalFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WindowsOptionalFeature>> GetWindowsOptionalFeature(int id)
        {
          if (_context.WindowsOptionalFeatures == null)
          {
              return NotFound();
          }
            var windowsOptionalFeature = await _context.WindowsOptionalFeatures.FindAsync(id);

            if (windowsOptionalFeature == null)
            {
                return NotFound();
            }

            return windowsOptionalFeature;
        }

        // PUT: v1WindowsOptionalFeature/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWindowsOptionalFeature(int id, WindowsOptionalFeature windowsOptionalFeature)
        {
            if (id != windowsOptionalFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(windowsOptionalFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WindowsOptionalFeatureExists(id))
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

        // POST: v1WindowsOptionalFeature
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WindowsOptionalFeature>> PostWindowsOptionalFeature(WindowsOptionalFeature windowsOptionalFeature)
        {
          if (_context.WindowsOptionalFeatures == null)
          {
              return Problem("Entity set 'DefaultDbContext.WindowsOptionalFeatures'  is null.");
          }
            _context.WindowsOptionalFeatures.Add(windowsOptionalFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindowsOptionalFeature", new { id = windowsOptionalFeature.Id }, windowsOptionalFeature);
        }

        // DELETE: v1WindowsOptionalFeature/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWindowsOptionalFeature(int id)
        {
            if (_context.WindowsOptionalFeatures == null)
            {
                return NotFound();
            }
            var windowsOptionalFeature = await _context.WindowsOptionalFeatures.FindAsync(id);
            if (windowsOptionalFeature == null)
            {
                return NotFound();
            }

            _context.WindowsOptionalFeatures.Remove(windowsOptionalFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WindowsOptionalFeatureExists(int id)
        {
            return (_context.WindowsOptionalFeatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

