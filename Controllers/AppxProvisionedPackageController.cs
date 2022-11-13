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
    public class AppxProvisionedPackageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public AppxProvisionedPackageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1AppxProvisionedPackage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackages()
        {
          if (_context.AppxProvisionedPackages == null)
          {
              return NotFound();
          }
            return await _context.AppxProvisionedPackages.ToListAsync();
        }

        // GET: v1AppxProvisionedPackage/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppxProvisionedPackage>> GetAppxProvisionedPackage(int id)
        {
          if (_context.AppxProvisionedPackages == null)
          {
              return NotFound();
          }
            var appxProvisionedPackage = await _context.AppxProvisionedPackages.FindAsync(id);

            if (appxProvisionedPackage == null)
            {
                return NotFound();
            }

            return appxProvisionedPackage;
        }

        // PUT: v1AppxProvisionedPackage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAppxProvisionedPackage(int id, AppxProvisionedPackage appxProvisionedPackage)
        {
            if (id != appxProvisionedPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(appxProvisionedPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppxProvisionedPackageExists(id))
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

        // POST: v1AppxProvisionedPackage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppxProvisionedPackage>> PostAppxProvisionedPackage(AppxProvisionedPackage appxProvisionedPackage)
        {
          if (_context.AppxProvisionedPackages == null)
          {
              return Problem("Entity set 'DefaultDbContext.AppxProvisionedPackages'  is null.");
          }
            _context.AppxProvisionedPackages.Add(appxProvisionedPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppxProvisionedPackage", new { id = appxProvisionedPackage.Id }, appxProvisionedPackage);
        }

        // DELETE: v1AppxProvisionedPackage/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAppxProvisionedPackage(int id)
        {
            if (_context.AppxProvisionedPackages == null)
            {
                return NotFound();
            }
            var appxProvisionedPackage = await _context.AppxProvisionedPackages.FindAsync(id);
            if (appxProvisionedPackage == null)
            {
                return NotFound();
            }

            _context.AppxProvisionedPackages.Remove(appxProvisionedPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppxProvisionedPackageExists(int id)
        {
            return (_context.AppxProvisionedPackages?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1/AppxProvisionedPackage/displayname/{displayName}
        [HttpGet("displayname/{displayname}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageByDisplayName([FromRoute]string displayname)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.DisplayName == displayname);
    
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/arch/{arch}
        [HttpGet("arch/{arch}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageByArch([FromRoute]string arch)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.Arch.Contains(arch));
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/lcid/{lcid}
        [HttpGet("lcid/{lcid}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageByLcid([FromRoute]string lcid)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.Lcid.Contains(lcid));
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/supportedwindowsversions/{supportedwindowsversion}
        [HttpGet("supportedwindowsversions/{supportedwindowsversion}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageBySupportedWindowsVersion([FromRoute]string supportedwindowsversion)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.SupportedWindowsVersions.Contains(supportedwindowsversion));
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/supportedwindowseditions/{supportedwindowsedition}
        [HttpGet("supportedwindowseditions/{supportedwindowsedition}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageBySupportedWindowsEditions([FromRoute]string supportedwindowsedition)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.SupportedWindowsEditions.Contains(supportedwindowsedition));
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/supportedwindowsreleases/{supportedwindowsrelease}
        [HttpGet("supportedwindowsreleases/{supportedwindowsrelease}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageBySupportedWindowsReleases([FromRoute]string supportedwindowsrelease)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => a.SupportedWindowsReleases.Contains(supportedwindowsrelease));
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/multisearch/{supportedwindowsversion}/{supportedwindowsedition}/{supportedwindowsrelease}
        [HttpGet("multisearch/{supportedwindowsversion}/{supportedwindowsedition}/{supportedwindowsrelease}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageMultiSearch(
            [FromRoute]string supportedwindowsversion,
            [FromRoute]string supportedwindowsedition,
            [FromRoute]string supportedwindowsrelease)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => 
                                a.SupportedWindowsVersions.Contains(supportedwindowsversion) &&
                                a.SupportedWindowsEditions.Contains(supportedwindowsedition) &&
                                a.SupportedWindowsReleases.Contains(supportedwindowsrelease)
                            );
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }

        // GET: v1/AppxProvisionedPackage/multiarchsearch/{version}/{edition}/{release}/{arch}
        [HttpGet("multiarchsearch/{version}/{edition}/{release}/{arch}")]
        public async Task<ActionResult<IEnumerable<AppxProvisionedPackage>>> GetAppxProvisionedPackageMultiArchSearch(
            [FromRoute]string version,
            [FromRoute]string edition,
            [FromRoute]string release,
            [FromRoute]string arch)
        {
            var packages = _context.AppxProvisionedPackages.Where(a => 
                                a.SupportedWindowsVersions.Contains(version) &&
                                a.SupportedWindowsEditions.Contains(edition) &&
                                a.SupportedWindowsReleases.Contains(release) &&
                                a.Arch.Contains(arch)
                            );
            
            if (packages.Count() == 0)
            {
                return NotFound();
            }

            return await packages.ToListAsync();
        }
    }
}


