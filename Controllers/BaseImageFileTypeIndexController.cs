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
    public class BaseImageFileTypeIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public BaseImageFileTypeIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1BaseImageFileTypeIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseImageFileTypeIndex>>> GetBaseImageFileTypeIndices()
        {
          if (_context.BaseImageFileTypeIndices == null)
          {
              return NotFound();
          }
            return await _context.BaseImageFileTypeIndices.ToListAsync();
        }

        // GET: v1BaseImageFileTypeIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseImageFileTypeIndex>> GetBaseImageFileTypeIndex(int id)
        {
          if (_context.BaseImageFileTypeIndices == null)
          {
              return NotFound();
          }
            var baseImageFileTypeIndex = await _context.BaseImageFileTypeIndices.FindAsync(id);

            if (baseImageFileTypeIndex == null)
            {
                return NotFound();
            }

            return baseImageFileTypeIndex;
        }

        // PUT: v1BaseImageFileTypeIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseImageFileTypeIndex(int id, BaseImageFileTypeIndex baseImageFileTypeIndex)
        {
            if (id != baseImageFileTypeIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseImageFileTypeIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseImageFileTypeIndexExists(id))
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

        // POST: v1BaseImageFileTypeIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseImageFileTypeIndex>> PostBaseImageFileTypeIndex(BaseImageFileTypeIndex baseImageFileTypeIndex)
        {
          if (_context.BaseImageFileTypeIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.BaseImageFileTypeIndices'  is null.");
          }
            _context.BaseImageFileTypeIndices.Add(baseImageFileTypeIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseImageFileTypeIndex", new { id = baseImageFileTypeIndex.Id }, baseImageFileTypeIndex);
        }

        // DELETE: v1BaseImageFileTypeIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseImageFileTypeIndex(int id)
        {
            if (_context.BaseImageFileTypeIndices == null)
            {
                return NotFound();
            }
            var baseImageFileTypeIndex = await _context.BaseImageFileTypeIndices.FindAsync(id);
            if (baseImageFileTypeIndex == null)
            {
                return NotFound();
            }

            _context.BaseImageFileTypeIndices.Remove(baseImageFileTypeIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseImageFileTypeIndexExists(int id)
        {
            return (_context.BaseImageFileTypeIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

