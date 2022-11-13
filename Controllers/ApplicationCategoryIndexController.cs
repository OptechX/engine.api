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
    [Route("v1/[controller]")]
    [ApiController]
    public class ApplicationCategoryIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public ApplicationCategoryIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/ApplicationCategoryIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationCategoryIndex>>> GetApplicationCategoryIndices()
        {
          if (_context.ApplicationCategoryIndices == null)
          {
              return NotFound();
          }
            return await _context.ApplicationCategoryIndices.ToListAsync();
        }

        // GET: v1/ApplicationCategoryIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationCategoryIndex>> GetApplicationCategoryIndex(int id)
        {
          if (_context.ApplicationCategoryIndices == null)
          {
              return NotFound();
          }
            var applicationCategoryIndex = await _context.ApplicationCategoryIndices.FindAsync(id);

            if (applicationCategoryIndex == null)
            {
                return NotFound();
            }

            return applicationCategoryIndex;
        }

        // PUT: v1/ApplicationCategoryIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationCategoryIndex(int id, ApplicationCategoryIndex applicationCategoryIndex)
        {
            if (id != applicationCategoryIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationCategoryIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationCategoryIndexExists(id))
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

        // POST: v1/ApplicationCategoryIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationCategoryIndex>> PostApplicationCategoryIndex(ApplicationCategoryIndex applicationCategoryIndex)
        {
          if (_context.ApplicationCategoryIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.ApplicationCategoryIndices'  is null.");
          }
            _context.ApplicationCategoryIndices.Add(applicationCategoryIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationCategoryIndex", new { id = applicationCategoryIndex.Id }, applicationCategoryIndex);
        }

        // DELETE: v1/ApplicationCategoryIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationCategoryIndex(int id)
        {
            if (_context.ApplicationCategoryIndices == null)
            {
                return NotFound();
            }
            var applicationCategoryIndex = await _context.ApplicationCategoryIndices.FindAsync(id);
            if (applicationCategoryIndex == null)
            {
                return NotFound();
            }

            _context.ApplicationCategoryIndices.Remove(applicationCategoryIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationCategoryIndexExists(int id)
        {
            return (_context.ApplicationCategoryIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


