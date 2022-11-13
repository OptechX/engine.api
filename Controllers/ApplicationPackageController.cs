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
    public class ApplicationPackageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public ApplicationPackageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1ApplicationPackage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationPackage>>> GetApplicationPackages()
        {
          if (_context.ApplicationPackages == null)
          {
              return NotFound();
          }
            return await _context.ApplicationPackages.ToListAsync();
        }

        // GET: v1ApplicationPackage/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationPackage>> GetApplicationPackage(int id)
        {
          if (_context.ApplicationPackages == null)
          {
              return NotFound();
          }
            var applicationPackage = await _context.ApplicationPackages.FindAsync(id);

            if (applicationPackage == null)
            {
                return NotFound();
            }

            return applicationPackage;
        }

        // PUT: v1ApplicationPackage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutApplicationPackage(int id, ApplicationPackage applicationPackage)
        {
            if (id != applicationPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationPackageExists(id))
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

        // POST: v1ApplicationPackage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationPackage>> PostApplicationPackage(ApplicationPackage applicationPackage)
        {
          if (_context.ApplicationPackages == null)
          {
              return Problem("Entity set 'DefaultDbContext.ApplicationPackages'  is null.");
          }
            _context.ApplicationPackages.Add(applicationPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationPackage", new { id = applicationPackage.Id }, applicationPackage);
        }

        // DELETE: v1ApplicationPackage/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApplicationPackage(int id)
        {
            if (_context.ApplicationPackages == null)
            {
                return NotFound();
            }
            var applicationPackage = await _context.ApplicationPackages.FindAsync(id);
            if (applicationPackage == null)
            {
                return NotFound();
            }

            _context.ApplicationPackages.Remove(applicationPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationPackageExists(int id)
        {
            return (_context.ApplicationPackages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}



