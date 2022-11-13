using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;
using api.engine_v2.Models.Shared.Enums;
using Stackoverflow.Answers.Helpers;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ApplicationPackageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public ApplicationPackageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/ApplicationPackage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> GetApplicationPackages()
        {
          if (_context.ApplicationPackages == null)
          {
              return NotFound();
          }
            return await _context.ApplicationPackages.ToListAsync();
        }

        // GET: v1/ApplicationPackage/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationPackage>> GetApplicationPackage(int id)
        {
          if (_context.ApplicationPackages == null)
          {
              return NotFound();
          }
            var applicationPackage = await _context.ApplicationPackages.FindAsync(id);

            if (applicationPackage == null)
            {
                return NotFound();
            }

            return applicationPackage;
        }

        // PUT: v1/ApplicationPackage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutApplicationPackage(int id, ApplicationPackage applicationPackage)
        {
            if (id != applicationPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationPackageExists(id))
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

        // POST: v1/ApplicationPackage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationPackage>> PostApplicationPackage(ApplicationPackage applicationPackage)
        {
          if (_context.ApplicationPackages == null)
          {
              return Problem("Entity set 'DefaultDbContext.ApplicationPackages'  is null.");
          }
            _context.ApplicationPackages.Add(applicationPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationPackage", new { id = applicationPackage.Id }, applicationPackage);
        }

        // DELETE: v1/ApplicationPackage/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApplicationPackage(int id)
        {
            if (_context.ApplicationPackages == null)
            {
                return NotFound();
            }
            var applicationPackage = await _context.ApplicationPackages.FindAsync(id);
            if (applicationPackage == null)
            {
                return NotFound();
            }

            _context.ApplicationPackages.Remove(applicationPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationPackageExists(int id)
        {
            return (_context.ApplicationPackages?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1/ApplicationPackage/uid/{uid}
        [HttpGet("uid/{uid}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByUid([FromRoute] string uid)
        {
            var applications = _context.ApplicationPackages.Where(a => a.UID == uid);

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/uid/{uid}
        [HttpGet("uuid/{uuid}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByUuid([FromRoute] string uuid)
        {
            var applications = _context.ApplicationPackages.Where(a => a.UUID.ToString() == uuid);

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/rebootrequired/{rebootrequired}
        [HttpGet("rebootrequired/{rebootrequired}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByRebootRequired([FromRoute] bool rebootrequired)
        {
            var applications = _context.ApplicationPackages.Where(a => a.RebootRequired == rebootrequired);

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/lcid/{lcid}
        [HttpGet("lcid/{lcid}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByLcid([FromRoute] string lcid)
        {
            var applications = _context.ApplicationPackages.Where(a => a.Lcid == lcid);
            //var applications = _context.ApplicationPackages.Where(a => a.Lcid == EnumExtensions.GetValueFromEnumMember<Lcid>(lcid));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/cpuarch/{cpuarch}
        [HttpGet("cpuarch/{cpuarch}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByCpuArch([FromRoute] string cpuarch)
        {
            var applications = _context.ApplicationPackages.Where(a => a.CpuArch == EnumExtensions.GetValueFromEnumMember<CpuArch>(cpuarch));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/executable/{executable}
        [HttpGet("executable/{executable}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByExecutable([FromRoute] string executable)
        {
            var applications = _context.ApplicationPackages.Where(a => a.Executable == EnumExtensions.GetValueFromEnumMember<Executable>(executable));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/ApplicationPackage/packagedetection/{packagedetection}
        [HttpGet("packagedetection/{packagedetection}")]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> ApplicationPackageByPackageDetection([FromRoute] string packagedetection)
        {
            var applications = _context.ApplicationPackages.Where(a => a.PackageDetection == EnumExtensions.GetValueFromEnumMember<PackageDetection>(packagedetection));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }
    }
}




