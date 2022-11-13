using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DriversCoreController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public DriversCoreController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/DriversCore
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriverCores()
        {
          if (_context.DriverCores == null)
          {
              return NotFound();
          }
            return await _context.DriverCores.ToListAsync();
        }

        // GET: v1/DriversCore/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DriversCore>> GetDriversCore(int id)
        {
          if (_context.DriverCores == null)
          {
              return NotFound();
          }
            var driversCore = await _context.DriverCores.FindAsync(id);

            if (driversCore == null)
            {
                return NotFound();
            }

            return driversCore;
        }

        // PUT: v1/DriversCore/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDriversCore(int id, DriversCore driversCore)
        {
            if (id != driversCore.Id)
            {
                return BadRequest();
            }

            _context.Entry(driversCore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversCoreExists(id))
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

        // POST: v1/DriversCore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<DriversCore>> PostDriversCore(DriversCore driversCore)
        {
          if (_context.DriverCores == null)
          {
              return Problem("Entity set 'DefaultDbContext.DriverCores'  is null.");
          }
            _context.DriverCores.Add(driversCore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriversCore", new { id = driversCore.Id }, driversCore);
        }

        // DELETE: v1/DriversCore/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDriversCore(int id)
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }
            var driversCore = await _context.DriverCores.FindAsync(id);
            if (driversCore == null)
            {
                return NotFound();
            }

            _context.DriverCores.Remove(driversCore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriversCoreExists(int id)
        {
            return (_context.DriverCores?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1//DriversCore/uid/{uid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("uid/{uid}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByUID([FromRoute] string uid)
        {
            var drivers = _context.DriverCores.Where(a => a.UID.ToLower() == uid.ToLower());

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/oem/{oem}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("oem/{oem}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByOriginalEquipmentManufacturer([FromRoute] string oem)
        {
            var drivers = _context.DriverCores.Where(a => a.OriginalEquipmentManufacturer.ToLower() == oem.ToLower());

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/make/{make}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("make/{make}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByMake([FromRoute] string make)
        {
            var drivers = _context.DriverCores.Where(a => a.Make.ToLower() == make.ToLower());

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/model/{model}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("model/{model}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByModel([FromRoute] string model)
        {
            var drivers = _context.DriverCores.Where(a => a.Model.ToLower() == model.ToLower());

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/productionyear/{productionyear:int}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("productionyear/{productionyear:int}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByProductionYear([FromRoute] int productionyear)
        {
            var drivers = _context.DriverCores.Where(a => a.ProductionYear == productionyear);

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/cpuarch/{cpuarch}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("cpuarch/{cpuarch}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByCpuArch([FromRoute] string cpuarch)
        {
            var drivers = _context.DriverCores.Where(a => a.CpuArch.Contains(cpuarch.ToLower()));

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/windowsos/{windowsos}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("windowsos/{windowsos}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByWindowsOS([FromRoute] string windowsos)
        {
            var drivers = _context.DriverCores.Where(a => a.WindowsOS.Contains(windowsos));

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/globalsearch/{searchterm}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("globalsearch/{searchterm}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByGlobalSearch([FromRoute] string searchterm)
        {
            var drivers = _context.DriverCores.Where(a =>
                a.Make.ToLower().Contains(searchterm.ToLower()) ||
                a.Model.ToLower().Contains(searchterm.ToLower()) ||
                a.OriginalEquipmentManufacturer.ToLower().Contains(searchterm.ToLower())
            );

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }

        // GET: v1//DriversCore/page4/{windowsos}/{arch}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("page4/{windowsos}/{arch}")]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriversCoreByPage4Search(
            [FromRoute] string windowsos,
            [FromRoute] string arch)
        {
            var drivers = _context.DriverCores.Where(a =>
                a.WindowsOS.Contains(windowsos) &&
                a.CpuArch.Contains(arch)
            );

            if (drivers.Count() == 0)
            {
                return NotFound();
            }

            return await drivers.ToListAsync();
        }
    }
}





