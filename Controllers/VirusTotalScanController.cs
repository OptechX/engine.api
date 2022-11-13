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
    public class VirusTotalScanController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public VirusTotalScanController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1VirusTotalScan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VirusTotalScan>>> GetVirusTotalScans()
        {
          if (_context.VirusTotalScans == null)
          {
              return NotFound();
          }
            return await _context.VirusTotalScans.ToListAsync();
        }

        // GET: v1VirusTotalScan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VirusTotalScan>> GetVirusTotalScan(int id)
        {
          if (_context.VirusTotalScans == null)
          {
              return NotFound();
          }
            var virusTotalScan = await _context.VirusTotalScans.FindAsync(id);

            if (virusTotalScan == null)
            {
                return NotFound();
            }

            return virusTotalScan;
        }

        // PUT: v1VirusTotalScan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirusTotalScan(int id, VirusTotalScan virusTotalScan)
        {
            if (id != virusTotalScan.Id)
            {
                return BadRequest();
            }

            _context.Entry(virusTotalScan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirusTotalScanExists(id))
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

        // POST: v1VirusTotalScan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VirusTotalScan>> PostVirusTotalScan(VirusTotalScan virusTotalScan)
        {
          if (_context.VirusTotalScans == null)
          {
              return Problem("Entity set 'DefaultDbContext.VirusTotalScans'  is null.");
          }
            _context.VirusTotalScans.Add(virusTotalScan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVirusTotalScan", new { id = virusTotalScan.Id }, virusTotalScan);
        }

        // DELETE: v1VirusTotalScan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVirusTotalScan(int id)
        {
            if (_context.VirusTotalScans == null)
            {
                return NotFound();
            }
            var virusTotalScan = await _context.VirusTotalScans.FindAsync(id);
            if (virusTotalScan == null)
            {
                return NotFound();
            }

            _context.VirusTotalScans.Remove(virusTotalScan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VirusTotalScanExists(int id)
        {
            return (_context.VirusTotalScans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

