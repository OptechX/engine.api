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
    public class ExecutableIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public ExecutableIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1ExecutableIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExecutableIndex>>> GetExecutableIndices()
        {
          if (_context.ExecutableIndices == null)
          {
              return NotFound();
          }
            return await _context.ExecutableIndices.ToListAsync();
        }

        // GET: v1ExecutableIndex/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExecutableIndex>> GetExecutableIndex(int id)
        {
          if (_context.ExecutableIndices == null)
          {
              return NotFound();
          }
            var executableIndex = await _context.ExecutableIndices.FindAsync(id);

            if (executableIndex == null)
            {
                return NotFound();
            }

            return executableIndex;
        }

        // PUT: v1ExecutableIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutExecutableIndex(int id, ExecutableIndex executableIndex)
        {
            if (id != executableIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(executableIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExecutableIndexExists(id))
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

        // POST: v1ExecutableIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExecutableIndex>> PostExecutableIndex(ExecutableIndex executableIndex)
        {
          if (_context.ExecutableIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.ExecutableIndices'  is null.");
          }
            _context.ExecutableIndices.Add(executableIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExecutableIndex", new { id = executableIndex.Id }, executableIndex);
        }

        // DELETE: v1ExecutableIndex/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExecutableIndex(int id)
        {
            if (_context.ExecutableIndices == null)
            {
                return NotFound();
            }
            var executableIndex = await _context.ExecutableIndices.FindAsync(id);
            if (executableIndex == null)
            {
                return NotFound();
            }

            _context.ExecutableIndices.Remove(executableIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExecutableIndexExists(int id)
        {
            return (_context.ExecutableIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


