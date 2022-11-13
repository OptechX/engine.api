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
    public class WinRefCore04ArchController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore04ArchController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WinRefCore04Arch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore04Arch>>> GetWinRefCore04Arches()
        {
          if (_context.WinRefCore04Arches == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore04Arches.ToListAsync();
        }

        // GET: v1WinRefCore04Arch/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WinRefCore04Arch>> GetWinRefCore04Arch(int id)
        {
          if (_context.WinRefCore04Arches == null)
          {
              return NotFound();
          }
            var winRefCore04Arch = await _context.WinRefCore04Arches.FindAsync(id);

            if (winRefCore04Arch == null)
            {
                return NotFound();
            }

            return winRefCore04Arch;
        }

        // PUT: v1WinRefCore04Arch/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWinRefCore04Arch(int id, WinRefCore04Arch winRefCore04Arch)
        {
            if (id != winRefCore04Arch.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore04Arch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore04ArchExists(id))
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

        // POST: v1WinRefCore04Arch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinRefCore04Arch>> PostWinRefCore04Arch(WinRefCore04Arch winRefCore04Arch)
        {
          if (_context.WinRefCore04Arches == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore04Arches'  is null.");
          }
            _context.WinRefCore04Arches.Add(winRefCore04Arch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore04Arch", new { id = winRefCore04Arch.Id }, winRefCore04Arch);
        }

        // DELETE: v1WinRefCore04Arch/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWinRefCore04Arch(int id)
        {
            if (_context.WinRefCore04Arches == null)
            {
                return NotFound();
            }
            var winRefCore04Arch = await _context.WinRefCore04Arches.FindAsync(id);
            if (winRefCore04Arch == null)
            {
                return NotFound();
            }

            _context.WinRefCore04Arches.Remove(winRefCore04Arch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore04ArchExists(int id)
        {
            return (_context.WinRefCore04Arches?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1/WinRefCore04Arch/{release}/{edition}/{version}
        [HttpGet("{release}/{edition}/{version}")]
        public async Task<ActionResult<IEnumerable<WinRefCore04Arch>>> GetWinRefCore04ArchIndexSearch(
            [FromRoute]string release,
            [FromRoute]string edition,
            [FromRoute]string version)
        {
            var results = _context.WinRefCore04Arches.Where(a => 
                a.Release == release &&
                a.Edition == edition &&
                a.Version == version);
            
            if (results.Count() == 0)
            {
                return NotFound();
            }

            return await results.ToListAsync();
        }
    }
}


