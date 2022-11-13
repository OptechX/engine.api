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
    public class CpuArchIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public CpuArchIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1CpuArchIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CpuArchIndex>>> GetCpuArchIndices()
        {
          if (_context.CpuArchIndices == null)
          {
              return NotFound();
          }
            return await _context.CpuArchIndices.ToListAsync();
        }

        // GET: v1CpuArchIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CpuArchIndex>> GetCpuArchIndex(int id)
        {
          if (_context.CpuArchIndices == null)
          {
              return NotFound();
          }
            var cpuArchIndex = await _context.CpuArchIndices.FindAsync(id);

            if (cpuArchIndex == null)
            {
                return NotFound();
            }

            return cpuArchIndex;
        }

        // PUT: v1CpuArchIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpuArchIndex(int id, CpuArchIndex cpuArchIndex)
        {
            if (id != cpuArchIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(cpuArchIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpuArchIndexExists(id))
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

        // POST: v1CpuArchIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CpuArchIndex>> PostCpuArchIndex(CpuArchIndex cpuArchIndex)
        {
          if (_context.CpuArchIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.CpuArchIndices'  is null.");
          }
            _context.CpuArchIndices.Add(cpuArchIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpuArchIndex", new { id = cpuArchIndex.Id }, cpuArchIndex);
        }

        // DELETE: v1CpuArchIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCpuArchIndex(int id)
        {
            if (_context.CpuArchIndices == null)
            {
                return NotFound();
            }
            var cpuArchIndex = await _context.CpuArchIndices.FindAsync(id);
            if (cpuArchIndex == null)
            {
                return NotFound();
            }

            _context.CpuArchIndices.Remove(cpuArchIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CpuArchIndexExists(int id)
        {
            return (_context.CpuArchIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

