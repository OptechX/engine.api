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
    public class RegistryKeyController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public RegistryKeyController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]egistryKey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistryKey>>> GetRegistryKeys()
        {
          if (_context.RegistryKeys == null)
          {
              return NotFound();
          }
            return await _context.RegistryKeys.ToListAsync();
        }

        // GET: v1//[controller]egistryKey/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RegistryKey>> GetRegistryKey(int id)
        {
          if (_context.RegistryKeys == null)
          {
              return NotFound();
          }
            var registryKey = await _context.RegistryKeys.FindAsync(id);

            if (registryKey == null)
            {
                return NotFound();
            }

            return registryKey;
        }

        // PUT: v1//[controller]egistryKey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutRegistryKey(int id, RegistryKey registryKey)
        {
            if (id != registryKey.Id)
            {
                return BadRequest();
            }

            _context.Entry(registryKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistryKeyExists(id))
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

        // POST: v1//[controller]egistryKey
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistryKey>> PostRegistryKey(RegistryKey registryKey)
        {
          if (_context.RegistryKeys == null)
          {
              return Problem("Entity set 'DefaultDbContext.RegistryKeys'  is null.");
          }
            _context.RegistryKeys.Add(registryKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistryKey", new { id = registryKey.Id }, registryKey);
        }

        // DELETE: v1//[controller]egistryKey/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRegistryKey(int id)
        {
            if (_context.RegistryKeys == null)
            {
                return NotFound();
            }
            var registryKey = await _context.RegistryKeys.FindAsync(id);
            if (registryKey == null)
            {
                return NotFound();
            }

            _context.RegistryKeys.Remove(registryKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistryKeyExists(int id)
        {
            return (_context.RegistryKeys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




