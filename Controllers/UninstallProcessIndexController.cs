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
    public class UninstallProcessIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public UninstallProcessIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: api/UninstallProcessIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UninstallProcessIndex>>> GetUninstallProcessIndices()
        {
          if (_context.UninstallProcessIndices == null)
          {
              return NotFound();
          }
            return await _context.UninstallProcessIndices.ToListAsync();
        }

        // GET: api/UninstallProcessIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UninstallProcessIndex>> GetUninstallProcessIndex(int id)
        {
          if (_context.UninstallProcessIndices == null)
          {
              return NotFound();
          }
            var uninstallProcessIndex = await _context.UninstallProcessIndices.FindAsync(id);

            if (uninstallProcessIndex == null)
            {
                return NotFound();
            }

            return uninstallProcessIndex;
        }

        // PUT: api/UninstallProcessIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUninstallProcessIndex(int id, UninstallProcessIndex uninstallProcessIndex)
        {
            if (id != uninstallProcessIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(uninstallProcessIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UninstallProcessIndexExists(id))
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

        // POST: api/UninstallProcessIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UninstallProcessIndex>> PostUninstallProcessIndex(UninstallProcessIndex uninstallProcessIndex)
        {
          if (_context.UninstallProcessIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.UninstallProcessIndices'  is null.");
          }
            _context.UninstallProcessIndices.Add(uninstallProcessIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUninstallProcessIndex", new { id = uninstallProcessIndex.Id }, uninstallProcessIndex);
        }

        // DELETE: api/UninstallProcessIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUninstallProcessIndex(int id)
        {
            if (_context.UninstallProcessIndices == null)
            {
                return NotFound();
            }
            var uninstallProcessIndex = await _context.UninstallProcessIndices.FindAsync(id);
            if (uninstallProcessIndex == null)
            {
                return NotFound();
            }

            _context.UninstallProcessIndices.Remove(uninstallProcessIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UninstallProcessIndexExists(int id)
        {
            return (_context.UninstallProcessIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
