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
    public class OriginalEquipmentManufacturerContactController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public OriginalEquipmentManufacturerContactController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1OriginalEquipmentManufacturerContact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OriginalEquipmentManufacturerContact>>> GetOriginalEquipmentManufacturerContacts()
        {
          if (_context.OriginalEquipmentManufacturerContacts == null)
          {
              return NotFound();
          }
            return await _context.OriginalEquipmentManufacturerContacts.ToListAsync();
        }

        // GET: v1OriginalEquipmentManufacturerContact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OriginalEquipmentManufacturerContact>> GetOriginalEquipmentManufacturerContact(int id)
        {
          if (_context.OriginalEquipmentManufacturerContacts == null)
          {
              return NotFound();
          }
            var originalEquipmentManufacturerContact = await _context.OriginalEquipmentManufacturerContacts.FindAsync(id);

            if (originalEquipmentManufacturerContact == null)
            {
                return NotFound();
            }

            return originalEquipmentManufacturerContact;
        }

        // PUT: v1OriginalEquipmentManufacturerContact/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOriginalEquipmentManufacturerContact(int id, OriginalEquipmentManufacturerContact originalEquipmentManufacturerContact)
        {
            if (id != originalEquipmentManufacturerContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(originalEquipmentManufacturerContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginalEquipmentManufacturerContactExists(id))
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

        // POST: v1OriginalEquipmentManufacturerContact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OriginalEquipmentManufacturerContact>> PostOriginalEquipmentManufacturerContact(OriginalEquipmentManufacturerContact originalEquipmentManufacturerContact)
        {
          if (_context.OriginalEquipmentManufacturerContacts == null)
          {
              return Problem("Entity set 'DefaultDbContext.OriginalEquipmentManufacturerContacts'  is null.");
          }
            _context.OriginalEquipmentManufacturerContacts.Add(originalEquipmentManufacturerContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOriginalEquipmentManufacturerContact", new { id = originalEquipmentManufacturerContact.Id }, originalEquipmentManufacturerContact);
        }

        // DELETE: v1OriginalEquipmentManufacturerContact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOriginalEquipmentManufacturerContact(int id)
        {
            if (_context.OriginalEquipmentManufacturerContacts == null)
            {
                return NotFound();
            }
            var originalEquipmentManufacturerContact = await _context.OriginalEquipmentManufacturerContacts.FindAsync(id);
            if (originalEquipmentManufacturerContact == null)
            {
                return NotFound();
            }

            _context.OriginalEquipmentManufacturerContacts.Remove(originalEquipmentManufacturerContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OriginalEquipmentManufacturerContactExists(int id)
        {
            return (_context.OriginalEquipmentManufacturerContacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

