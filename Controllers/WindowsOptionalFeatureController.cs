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
        [HttpGet("{id:int}")]
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
        [HttpPut("{id:int}")]
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
        [HttpDelete("{id:int}")]
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

        // GET: v1/WindowsOptionalFeature/featurename/{featurename}
        [HttpGet("featurename/{featurename}")]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatureByFeatureName([FromRoute]string featurename)
        {
            var features = _context.WindowsOptionalFeatures.Where(a => a.FeatureName.ToLower().Contains(featurename.ToLower()));

            if (features.Count() == 0)
            {
                return NotFound();
            }

            return await features.ToListAsync();
        }

        // GET: v1/WindowsOptionalFeature/supportedwindowsversions/{version}
        [HttpGet("supportedwindowsversions/{version}")]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatureBySupportedWindowsVersions([FromRoute]string version)
        {
            var features = _context.WindowsOptionalFeatures.Where(a => a.SupportedWindowsVersions.Contains(version));

            if (features.Count() == 0)
            {
                return NotFound();
            }

            return await features.ToListAsync();
        }

        // GET: v1/WindowsOptionalFeature/supportedwindowseditions/{edition}
        [HttpGet("supportedwindowseditions/{edition}")]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatureBySupportedWindowsEditions([FromRoute]string edition)
        {
            var features = _context.WindowsOptionalFeatures.Where(a => a.SupportedWindowsEditions.Contains(edition));

            if (features.Count() == 0)
            {
                return NotFound();
            }

            return await features.ToListAsync();
        }

        // GET: v1/WindowsOptionalFeature/supportedwindowsreleases/{releases}
        [HttpGet("supportedwindowsreleases/{release}")]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatureBySupportedWindowsReleases([FromRoute]string release)
        {
            var features = _context.WindowsOptionalFeatures.Where(a => a.SupportedWindowsReleases.Contains(release));

            if (features.Count() == 0)
            {
                return NotFound();
            }

            return await features.ToListAsync();
        }

        // GET: v1/WindowsOptionalFeature/multisearch/{version}/{edition}/{release}
        [HttpGet("multisearch/{version}/{edition}/{release}")]
        public async Task<ActionResult<IEnumerable<WindowsOptionalFeature>>> GetWindowsOptionalFeatureMultiSearch(
            [FromRoute]string version,
            [FromRoute]string edition,
            [FromRoute]string release)
        {
            var features = _context.WindowsOptionalFeatures.Where(a => 
                                a.SupportedWindowsVersions.Contains(version) &&
                                a.SupportedWindowsEditions.Contains(edition) &&
                                a.SupportedWindowsReleases.Contains(release)
                            );
            
            if (features.Count() == 0)
            {
                return NotFound();
            }

            return await features.ToListAsync();
        }
    }
}



