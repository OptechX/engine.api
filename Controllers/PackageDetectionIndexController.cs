using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Shared;

namespace api.engine_v2.Controllers
{
    [Route("v1[controller]")]
    [ApiController]
    public class PackageDetectionIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public PackageDetectionIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1PackageDetectionIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageDetectionIndex>>> GetPackageDetectionIndices()
        {
          if (_context.PackageDetectionIndices == null)
          {
              return NotFound();
          }
            return await _context.PackageDetectionIndices.ToListAsync();
        }

        // GET: v1PackageDetectionIndex/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PackageDetectionIndex>> GetPackageDetectionIndex(int id)
        {
          if (_context.PackageDetectionIndices == null)
          {
              return NotFound();
          }
            var packageDetectionIndex = await _context.PackageDetectionIndices.FindAsync(id);

            if (packageDetectionIndex == null)
            {
                return NotFound();
            }

            return packageDetectionIndex;
        }

        // PUT: v1PackageDetectionIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPackageDetectionIndex(int id, PackageDetectionIndex packageDetectionIndex)
        {
            if (id != packageDetectionIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageDetectionIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageDetectionIndexExists(id))
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

        // POST: v1PackageDetectionIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageDetectionIndex>> PostPackageDetectionIndex(PackageDetectionIndex packageDetectionIndex)
        {
          if (_context.PackageDetectionIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.PackageDetectionIndices'  is null.");
          }
            _context.PackageDetectionIndices.Add(packageDetectionIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageDetectionIndex", new { id = packageDetectionIndex.Id }, packageDetectionIndex);
        }

        // DELETE: v1PackageDetectionIndex/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePackageDetectionIndex(int id)
        {
            if (_context.PackageDetectionIndices == null)
            {
                return NotFound();
            }
            var packageDetectionIndex = await _context.PackageDetectionIndices.FindAsync(id);
            if (packageDetectionIndex == null)
            {
                return NotFound();
            }

            _context.PackageDetectionIndices.Remove(packageDetectionIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageDetectionIndexExists(int id)
        {
            return (_context.PackageDetectionIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


