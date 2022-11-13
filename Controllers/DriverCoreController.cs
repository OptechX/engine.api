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
    [Route("api/[controller]")]
    [ApiController]
    public class DriverCoreController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public DriverCoreController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: api/DriverCore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetDriverCores()
        {
          if (_context.DriverCores == null)
          {
              return NotFound();
          }
            return await _context.DriverCores.ToListAsync();
        }

        // GET: api/DriverCore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverCore>> GetDriverCore(int id)
        {
          if (_context.DriverCores == null)
          {
              return NotFound();
          }
            var driverCore = await _context.DriverCores.FindAsync(id);

            if (driverCore == null)
            {
                return NotFound();
            }

            return driverCore;
        }

        // PUT: api/DriverCore/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverCore(int id, DriverCore driverCore)
        {
            if (id != driverCore.Id)
            {
                return BadRequest();
            }

            _context.Entry(driverCore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverCoreExists(id))
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

        // POST: api/DriverCore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverCore>> PostDriverCore(DriverCore driverCore)
        {
          if (_context.DriverCores == null)
          {
              return Problem("Entity set 'DefaultDbContext.DriverCores'  is null.");
          }
            _context.DriverCores.Add(driverCore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverCore", new { id = driverCore.Id }, driverCore);
        }

        // DELETE: api/DriverCore/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverCore(int id)
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }
            var driverCore = await _context.DriverCores.FindAsync(id);
            if (driverCore == null)
            {
                return NotFound();
            }

            _context.DriverCores.Remove(driverCore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverCoreExists(int id)
        {
            return (_context.DriverCores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
