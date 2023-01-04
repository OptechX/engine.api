using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Shared;
using Microsoft.AspNetCore.Cors;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CountryIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public CountryIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]ountryIndex
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryIndex>>> GetCountryIndices()
        {
          if (_context.CountryIndices == null)
          {
              return NotFound();
          }
            return await _context.CountryIndices.ToListAsync();
        }

        // GET: v1//[controller]ountryIndex/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CountryIndex>> GetCountryIndex(int id)
        {
          if (_context.CountryIndices == null)
          {
              return NotFound();
          }
            var countryIndex = await _context.CountryIndices.FindAsync(id);

            if (countryIndex == null)
            {
                return NotFound();
            }

            return countryIndex;
        }

        // PUT: v1//[controller]ountryIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCountryIndex(int id, CountryIndex countryIndex)
        {
            if (id != countryIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryIndexExists(id))
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

        // POST: v1//[controller]ountryIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<CountryIndex>> PostCountryIndex(CountryIndex countryIndex)
        {
          if (_context.CountryIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.CountryIndices'  is null.");
          }
            _context.CountryIndices.Add(countryIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryIndex", new { id = countryIndex.Id }, countryIndex);
        }

        // DELETE: v1//[controller]ountryIndex/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountryIndex(int id)
        {
            if (_context.CountryIndices == null)
            {
                return NotFound();
            }
            var countryIndex = await _context.CountryIndices.FindAsync(id);
            if (countryIndex == null)
            {
                return NotFound();
            }

            _context.CountryIndices.Remove(countryIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryIndexExists(int id)
        {
            return (_context.CountryIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}





