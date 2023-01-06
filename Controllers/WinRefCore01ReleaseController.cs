using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class WinRefCore01ReleaseController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore01ReleaseController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/WinRefCore01Release
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore01Release>>> GetWinRefCore01Releases()
        {
          if (_context.WinRefCore01Releases == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore01Releases.ToListAsync();
        }

        // GET: v1/WinRefCore01Release/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WinRefCore01Release>> GetWinRefCore01Release(int id)
        {
          if (_context.WinRefCore01Releases == null)
          {
              return NotFound();
          }
            var winRefCore01Release = await _context.WinRefCore01Releases.FindAsync(id);

            if (winRefCore01Release == null)
            {
                return NotFound();
            }

            return winRefCore01Release;
        }

        // PUT: v1/WinRefCore01Release/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWinRefCore01Release(int id, WinRefCore01Release winRefCore01Release)
        {
            if (id != winRefCore01Release.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore01Release).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore01ReleaseExists(id))
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

        // POST: v1/WinRefCore01Release
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<WinRefCore01Release>> PostWinRefCore01Release(WinRefCore01Release winRefCore01Release)
        {
          if (_context.WinRefCore01Releases == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore01Releases'  is null.");
          }
            _context.WinRefCore01Releases.Add(winRefCore01Release);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore01Release", new { id = winRefCore01Release.Id }, winRefCore01Release);
        }

        // DELETE: v1/WinRefCore01Release/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWinRefCore01Release(int id)
        {
            if (_context.WinRefCore01Releases == null)
            {
                return NotFound();
            }
            var winRefCore01Release = await _context.WinRefCore01Releases.FindAsync(id);
            if (winRefCore01Release == null)
            {
                return NotFound();
            }

            _context.WinRefCore01Releases.Remove(winRefCore01Release);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore01ReleaseExists(int id)
        {
            return (_context.WinRefCore01Releases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}





