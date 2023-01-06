using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Shared;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LocaleIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public LocaleIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]ocaleIndex
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocaleIndex>>> GetLocaleIndices()
        {
          if (_context.LocaleIndices == null)
          {
              return NotFound();
          }
            return await _context.LocaleIndices.ToListAsync();
        }

        // GET: v1//[controller]ocaleIndex/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocaleIndex>> GetLocaleIndex(int id)
        {
          if (_context.LocaleIndices == null)
          {
              return NotFound();
          }
            var localeIndex = await _context.LocaleIndices.FindAsync(id);

            if (localeIndex == null)
            {
                return NotFound();
            }

            return localeIndex;
        }

        // PUT: v1//[controller]ocaleIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutLocaleIndex(int id, LocaleIndex localeIndex)
        {
            if (id != localeIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(localeIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaleIndexExists(id))
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

        // POST: v1//[controller]ocaleIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<LocaleIndex>> PostLocaleIndex(LocaleIndex localeIndex)
        {
          if (_context.LocaleIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.LocaleIndices'  is null.");
          }
            _context.LocaleIndices.Add(localeIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocaleIndex", new { id = localeIndex.Id }, localeIndex);
        }

        // DELETE: v1//[controller]ocaleIndex/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLocaleIndex(int id)
        {
            if (_context.LocaleIndices == null)
            {
                return NotFound();
            }
            var localeIndex = await _context.LocaleIndices.FindAsync(id);
            if (localeIndex == null)
            {
                return NotFound();
            }

            _context.LocaleIndices.Remove(localeIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaleIndexExists(int id)
        {
            return (_context.LocaleIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}





