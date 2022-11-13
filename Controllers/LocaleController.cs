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
    public class LocaleController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public LocaleController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1Locale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locale>>> Getlocales()
        {
          if (_context.locales == null)
          {
              return NotFound();
          }
            return await _context.locales.ToListAsync();
        }

        // GET: v1Locale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locale>> GetLocale(int id)
        {
          if (_context.locales == null)
          {
              return NotFound();
          }
            var locale = await _context.locales.FindAsync(id);

            if (locale == null)
            {
                return NotFound();
            }

            return locale;
        }

        // PUT: v1Locale/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocale(int id, Locale locale)
        {
            if (id != locale.Id)
            {
                return BadRequest();
            }

            _context.Entry(locale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaleExists(id))
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

        // POST: v1Locale
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locale>> PostLocale(Locale locale)
        {
          if (_context.locales == null)
          {
              return Problem("Entity set 'DefaultDbContext.locales'  is null.");
          }
            _context.locales.Add(locale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocale", new { id = locale.Id }, locale);
        }

        // DELETE: v1Locale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocale(int id)
        {
            if (_context.locales == null)
            {
                return NotFound();
            }
            var locale = await _context.locales.FindAsync(id);
            if (locale == null)
            {
                return NotFound();
            }

            _context.locales.Remove(locale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaleExists(int id)
        {
            return (_context.locales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

