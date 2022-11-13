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
    public class DriversCoreController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public DriversCoreController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1DriversCore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriversCore>>> GetDriverCores()
        {
          if (_context.DriverCores == null)
          {
              return NotFound();
          }
            return await _context.DriverCores.ToListAsync();
        }

        // GET: v1DriversCore/5
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

        // PUT: v1DriversCore/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: v1DriversCore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: v1DriversCore/5
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
    }
}

