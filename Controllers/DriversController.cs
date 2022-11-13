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
    public class DriversController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public DriversController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            return await _context.Drivers.ToListAsync();
        }

        // GET: v1Drivers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Drivers>> GetDrivers(int id)
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            var drivers = await _context.Drivers.FindAsync(id);

            if (drivers == null)
            {
                return NotFound();
            }

            return drivers;
        }

        // PUT: v1Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDrivers(int id, Drivers drivers)
        {
            if (id != drivers.Id)
            {
                return BadRequest();
            }

            _context.Entry(drivers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversExists(id))
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

        // POST: v1Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drivers>> PostDrivers(Drivers drivers)
        {
          if (_context.Drivers == null)
          {
              return Problem("Entity set 'DefaultDbContext.Drivers'  is null.");
          }
            _context.Drivers.Add(drivers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrivers", new { id = drivers.Id }, drivers);
        }

        // DELETE: v1Drivers/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDrivers(int id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(drivers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriversExists(int id)
        {
            return (_context.Drivers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1/Drivers/uid/{uid}
        [HttpGet("uid/{uid}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByUid([FromRoute] string uid)
        {
            var drivers = _context.Drivers.Where(a => a.UID == uid);           //<- exact match

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/make/{make}
        [HttpGet("make/{make}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversBymake([FromRoute] string make)
        {
            var drivers = _context.Drivers.Where(a => a.Make == make);           //<- exact match

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/model/{model}
        [HttpGet("model/{model}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversBymodel([FromRoute] string model)
        {
            var drivers = _context.Drivers.Where(a => a.Model == model);           //<- exact match

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/cspversion/{cspversion}
        [HttpGet("cspversion/{cspversion}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversBycspversion([FromRoute] string cspversion)
        {
            var drivers = _context.Drivers.Where(a => a.CspVersion == cspversion);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/cspname/{cspname}
        [HttpGet("cspname/{cspname}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversBycspname([FromRoute] string cspname)
        {
            var drivers = _context.Drivers.Where(a => a.CspName == cspname);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/productionyear/{year}
        [HttpGet("productionyear/{year:int}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByYear([FromRoute] int year)
        {
            var drivers = _context.Drivers.Where(a => a.ProductionYear == year);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/x64
        [HttpGet("x64")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByX64()
        {
            var drivers = _context.Drivers.Where(a => a.x64 == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/x86
        [HttpGet("x86")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByX86()
        {
            var drivers = _context.Drivers.Where(a => a.x86 == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/arm64
        [HttpGet("arm64")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByArm64()
        {
            var drivers = _context.Drivers.Where(a => a.arm64 == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/aarch32
        [HttpGet("aarch32")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByAarch32()
        {
            var drivers = _context.Drivers.Where(a => a.aarch32 == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/latest
        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByLatest()
        {
            var drivers = _context.Drivers.Where(a => a.Latest == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/cpuarch/{arch}
        [HttpGet("cpuarch/{arch}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByCpuArch([FromRoute] string arch)
        {
            var drivers = _context.Drivers.Where(a => a.CpuArch.Contains(arch.ToLower()));

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/supportedwinver/{supportedwinver}
        [HttpGet("supportedwinver/{supportedwinver}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversBysupportedwinver([FromRoute] string supportedwinver)
        {
            var drivers = _context.Drivers.Where(a => a.SupportedWindowsVersion.Contains(supportedwinver.ToLower()));

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/oem/{oem}}
        [HttpGet("oem/{oem}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByOem([FromRoute] string oem)
        {
            //var drivers = _context.Drivers.Where(a => a.OriginalEquipmentManufacturer == EnumExtensions.GetValueFromEnumMember<OriginalEquipmentManufacturer>(oem));
            var drivers = _context.Drivers.Where(a => a.OriginalEquipmentManufacturer == oem);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/CloudDeploySupport
        [HttpGet("clouddeploysupport")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByCloudDeploySupport()
        {
            var drivers = _context.Drivers.Where(a => a.CloudDeploySupport == true);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/windowsrelease/{winrelease}}
        [HttpGet("windowsrelease/{winrelease}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversByWindowsRelease([FromRoute] string winrelease)
        {
            //var drivers = _context.Drivers.Where(a => a.WindowsRelease == EnumExtensions.GetValueFromEnumMember<WindowsRelease>(winrelease));
            var drivers = _context.Drivers.Where(a => a.WindowsRelease == winrelease);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1/Drivers/multisearch/{oem}/{arch}/{windowsrelease}
        [HttpGet("multisearch/{oem}/{arch}/{windowsrelease}")]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDriversMultiSearch(
            [FromRoute] string oem,
            [FromRoute] string arch,
            [FromRoute] string windowsrelease
        )
        {
            var drivers = _context.Drivers.Where(a =>
                a.OriginalEquipmentManufacturer == oem &&
                a.CpuArch.Contains(arch.ToLower()) &&
                a.WindowsRelease == windowsrelease
            );

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }
    }
}



