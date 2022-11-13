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
    public class WinRefCore03VersionController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore03VersionController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WinRefCore03Version
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore03Version>>> GetWinRefCore03Versions()
        {
          if (_context.WinRefCore03Versions == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore03Versions.ToListAsync();
        }

        // GET: v1WinRefCore03Version/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WinRefCore03Version>> GetWinRefCore03Version(int id)
        {
          if (_context.WinRefCore03Versions == null)
          {
              return NotFound();
          }
            var winRefCore03Version = await _context.WinRefCore03Versions.FindAsync(id);

            if (winRefCore03Version == null)
            {
                return NotFound();
            }

            return winRefCore03Version;
        }

        // PUT: v1WinRefCore03Version/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWinRefCore03Version(int id, WinRefCore03Version winRefCore03Version)
        {
            if (id != winRefCore03Version.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore03Version).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore03VersionExists(id))
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

        // POST: v1WinRefCore03Version
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinRefCore03Version>> PostWinRefCore03Version(WinRefCore03Version winRefCore03Version)
        {
          if (_context.WinRefCore03Versions == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore03Versions'  is null.");
          }
            _context.WinRefCore03Versions.Add(winRefCore03Version);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore03Version", new { id = winRefCore03Version.Id }, winRefCore03Version);
        }

        // DELETE: v1WinRefCore03Version/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWinRefCore03Version(int id)
        {
            if (_context.WinRefCore03Versions == null)
            {
                return NotFound();
            }
            var winRefCore03Version = await _context.WinRefCore03Versions.FindAsync(id);
            if (winRefCore03Version == null)
            {
                return NotFound();
            }

            _context.WinRefCore03Versions.Remove(winRefCore03Version);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore03VersionExists(int id)
        {
            return (_context.WinRefCore03Versions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


