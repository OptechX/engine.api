using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Shared;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LcidIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public LcidIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]cidIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LcidIndex>>> GetLcidIndices()
        {
          if (_context.LcidIndices == null)
          {
              return NotFound();
          }
            return await _context.LcidIndices.ToListAsync();
        }

        // GET: v1//[controller]cidIndex/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LcidIndex>> GetLcidIndex(int id)
        {
          if (_context.LcidIndices == null)
          {
              return NotFound();
          }
            var lcidIndex = await _context.LcidIndices.FindAsync(id);

            if (lcidIndex == null)
            {
                return NotFound();
            }

            return lcidIndex;
        }

        // PUT: v1//[controller]cidIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutLcidIndex(int id, LcidIndex lcidIndex)
        {
            if (id != lcidIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(lcidIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LcidIndexExists(id))
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

        // POST: v1//[controller]cidIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LcidIndex>> PostLcidIndex(LcidIndex lcidIndex)
        {
          if (_context.LcidIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.LcidIndices'  is null.");
          }
            _context.LcidIndices.Add(lcidIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLcidIndex", new { id = lcidIndex.Id }, lcidIndex);
        }

        // DELETE: v1//[controller]cidIndex/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLcidIndex(int id)
        {
            if (_context.LcidIndices == null)
            {
                return NotFound();
            }
            var lcidIndex = await _context.LcidIndices.FindAsync(id);
            if (lcidIndex == null)
            {
                return NotFound();
            }

            _context.LcidIndices.Remove(lcidIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LcidIndexExists(int id)
        {
            return (_context.LcidIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




