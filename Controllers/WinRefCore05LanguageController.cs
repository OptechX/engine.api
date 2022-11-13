using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;
using Microsoft.AspNetCore.Cors;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class WinRefCore05LanguageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore05LanguageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/WinRefCore05Language
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore05Language>>> GetWinRefCore05Languages()
        {
          if (_context.WinRefCore05Languages == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore05Languages.ToListAsync();
        }

        // GET: v1/WinRefCore05Language/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WinRefCore05Language>> GetWinRefCore05Language(int id)
        {
          if (_context.WinRefCore05Languages == null)
          {
              return NotFound();
          }
            var winRefCore05Language = await _context.WinRefCore05Languages.FindAsync(id);

            if (winRefCore05Language == null)
            {
                return NotFound();
            }

            return winRefCore05Language;
        }

        // PUT: v1/WinRefCore05Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWinRefCore05Language(int id, WinRefCore05Language winRefCore05Language)
        {
            if (id != winRefCore05Language.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore05Language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore05LanguageExists(id))
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

        // POST: v1/WinRefCore05Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<WinRefCore05Language>> PostWinRefCore05Language(WinRefCore05Language winRefCore05Language)
        {
          if (_context.WinRefCore05Languages == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore05Languages'  is null.");
          }
            _context.WinRefCore05Languages.Add(winRefCore05Language);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore05Language", new { id = winRefCore05Language.Id }, winRefCore05Language);
        }

        // DELETE: v1/WinRefCore05Language/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWinRefCore05Language(int id)
        {
            if (_context.WinRefCore05Languages == null)
            {
                return NotFound();
            }
            var winRefCore05Language = await _context.WinRefCore05Languages.FindAsync(id);
            if (winRefCore05Language == null)
            {
                return NotFound();
            }

            _context.WinRefCore05Languages.Remove(winRefCore05Language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore05LanguageExists(int id)
        {
            return (_context.WinRefCore05Languages?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1//WinRefCore05Language/{release}/{edition}/{version}/{arch}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{release}/{edition}/{version}/{arch}")]
        public async Task<ActionResult<IEnumerable<WinRefCore05Language>>> GetWinRefCore05MultiSearch(
            [FromRoute]string release,
            [FromRoute]string edition,
            [FromRoute]string version,
            [FromRoute]string arch)
        {
            var results = _context.WinRefCore05Languages.Where(a => 
                a.Release == release &&
                a.Edition == edition &&
                a.Version == version &&
                a.Arch == arch);
            
            if (results.Count() == 0)
            {
                return NotFound();
            }

            return await results.ToListAsync();
        }
    }
}





