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
    [Route("v1/[controller]")]
    [ApiController]
    public class WindowsCapabilityController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WindowsCapabilityController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/WindowsCapability
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilities()
        {
          if (_context.WindowsCapabilities == null)
          {
              return NotFound();
          }
            return await _context.WindowsCapabilities.ToListAsync();
        }

        // GET: v1/WindowsCapability/5
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

        // PUT: v1/WindowsCapability/5
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

        // POST: v1/WindowsCapability
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

        // DELETE: v1/WindowsCapability/5
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

        // GET: v1//WindowsCapability/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilityByName([FromRoute]string name)
        {
            var capability = _context.WindowsCapabilities.Where(a => a.Name == name);
            
            if (capability.Count() == 0)
            {
                return NotFound();
            }

            return await capability.ToListAsync();
        }

        // GET: v1//WindowsCapability/supportedwindowsversions/{version}
        [HttpGet("supportedwindowsversions/{version}")]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilityBySupportedWindowsVersions([FromRoute]string version)
        {
            var capability = _context.WindowsCapabilities.Where(a => a.SupportedWindowsVersions.Contains(version));

            if (capability.Count() == 0)
            {
                return NotFound();
            }

            return await capability.ToListAsync();
        }

        // GET: v1//WindowsCapability/supportedwindowseditions/{supportedwindowsedition}
        [HttpGet("supportedwindowseditions/{edition}")]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilityBySupportedWindowsEditions([FromRoute]string edition)
        {
            var capability = _context.WindowsCapabilities.Where(a => a.SupportedWindowsEditions.Contains(edition));

            if (capability.Count() == 0)
            {
                return NotFound();
            }

            return await capability.ToListAsync();
        }

        // GET: v1//WindowsCapability/supportedwindowsreleases/{supportedwindowsrelease}
        [HttpGet("supportedwindowsreleases/{release}")]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilityBySupportedWindowsReleases([FromRoute]string release)
        {
            var capability = _context.WindowsCapabilities.Where(a => a.SupportedWindowsReleases.Contains(release));

            if (capability.Count() == 0)
            {
                return NotFound();
            }

            return await capability.ToListAsync();
        }

        // GET: v1//WindowsCapability/multisearch/{supportedwindowsversion}/{supportedwindowsedition}/{supportedwindowsrelease}
        [HttpGet("multisearch/{version}/{edition}/{release}")]
        public async Task<ActionResult<IEnumerable<WindowsCapability>>> GetWindowsCapabilityMultiSearch(
            [FromRoute]string version,
            [FromRoute]string edition,
            [FromRoute]string release)
        {
            var capabilities = _context.WindowsCapabilities.Where(a =>
                a.SupportedWindowsVersions.Contains(version) &&
                a.SupportedWindowsEditions.Contains(edition) &&
                a.SupportedWindowsReleases.Contains(release));
            
            if (capabilities.Count() == 0)
            {
                return NotFound();
            }

            return await capabilities.ToListAsync();
        }
    }
}




