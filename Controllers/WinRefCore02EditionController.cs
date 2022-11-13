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
    public class WinRefCore02EditionController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WinRefCore02EditionController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1WinRefCore02Edition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinRefCore02Edition>>> GetWinRefCore02Editions()
        {
          if (_context.WinRefCore02Editions == null)
          {
              return NotFound();
          }
            return await _context.WinRefCore02Editions.ToListAsync();
        }

        // GET: v1WinRefCore02Edition/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WinRefCore02Edition>> GetWinRefCore02Edition(int id)
        {
          if (_context.WinRefCore02Editions == null)
          {
              return NotFound();
          }
            var winRefCore02Edition = await _context.WinRefCore02Editions.FindAsync(id);

            if (winRefCore02Edition == null)
            {
                return NotFound();
            }

            return winRefCore02Edition;
        }

        // PUT: v1WinRefCore02Edition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWinRefCore02Edition(int id, WinRefCore02Edition winRefCore02Edition)
        {
            if (id != winRefCore02Edition.Id)
            {
                return BadRequest();
            }

            _context.Entry(winRefCore02Edition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinRefCore02EditionExists(id))
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

        // POST: v1WinRefCore02Edition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinRefCore02Edition>> PostWinRefCore02Edition(WinRefCore02Edition winRefCore02Edition)
        {
          if (_context.WinRefCore02Editions == null)
          {
              return Problem("Entity set 'DefaultDbContext.WinRefCore02Editions'  is null.");
          }
            _context.WinRefCore02Editions.Add(winRefCore02Edition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinRefCore02Edition", new { id = winRefCore02Edition.Id }, winRefCore02Edition);
        }

        // DELETE: v1WinRefCore02Edition/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWinRefCore02Edition(int id)
        {
            if (_context.WinRefCore02Editions == null)
            {
                return NotFound();
            }
            var winRefCore02Edition = await _context.WinRefCore02Editions.FindAsync(id);
            if (winRefCore02Edition == null)
            {
                return NotFound();
            }

            _context.WinRefCore02Editions.Remove(winRefCore02Edition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinRefCore02EditionExists(int id)
        {
            return (_context.WinRefCore02Editions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


