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
    public class WinRefCore05LanguageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore05LanguageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: api/WinRefCore05Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore05Language>>> GetWinRefCore05Languages()
        {
          if (_context.WinRefCore05Languages == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore05Languages.ToListAsync();
        }

        // GET: api/WinRefCore05Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WinRefCore05Language>> GetWinRefCore05Language(int id)
        {
          if (_context.WinRefCore05Languages == null)
          {
              return NotFound();
          }
            var winRefCore05Language = await _context.WinRefCore05Languages.FindAsync(id);

            if (winRefCore05Language == null)
            {
                return NotFound();
            }

            return winRefCore05Language;
        }

        // PUT: api/WinRefCore05Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinRefCore05Language(int id, WinRefCore05Language winRefCore05Language)
        {
            if (id != winRefCore05Language.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore05Language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore05LanguageExists(id))
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

        // POST: api/WinRefCore05Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinRefCore05Language>> PostWinRefCore05Language(WinRefCore05Language winRefCore05Language)
        {
          if (_context.WinRefCore05Languages == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore05Languages'  is null.");
          }
            _context.WinRefCore05Languages.Add(winRefCore05Language);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore05Language", new { id = winRefCore05Language.Id }, winRefCore05Language);
        }

        // DELETE: api/WinRefCore05Language/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinRefCore05Language(int id)
        {
            if (_context.WinRefCore05Languages == null)
            {
                return NotFound();
            }
            var winRefCore05Language = await _context.WinRefCore05Languages.FindAsync(id);
            if (winRefCore05Language == null)
            {
                return NotFound();
            }

            _context.WinRefCore05Languages.Remove(winRefCore05Language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore05LanguageExists(int id)
        {
            return (_context.WinRefCore05Languages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
