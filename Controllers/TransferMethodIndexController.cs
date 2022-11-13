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
    [Route("v1/[controller]")]
    [ApiController]
    public class TransferMethodIndexController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public TransferMethodIndexController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1//[controller]ransferMethodIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferMethodIndex>>> GetTransferMethodIndices()
        {
          if (_context.TransferMethodIndices == null)
          {
              return NotFound();
          }
            return await _context.TransferMethodIndices.ToListAsync();
        }

        // GET: v1//[controller]ransferMethodIndex/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransferMethodIndex>> GetTransferMethodIndex(int id)
        {
          if (_context.TransferMethodIndices == null)
          {
              return NotFound();
          }
            var transferMethodIndex = await _context.TransferMethodIndices.FindAsync(id);

            if (transferMethodIndex == null)
            {
                return NotFound();
            }

            return transferMethodIndex;
        }

        // PUT: v1//[controller]ransferMethodIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTransferMethodIndex(int id, TransferMethodIndex transferMethodIndex)
        {
            if (id != transferMethodIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferMethodIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferMethodIndexExists(id))
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

        // POST: v1//[controller]ransferMethodIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransferMethodIndex>> PostTransferMethodIndex(TransferMethodIndex transferMethodIndex)
        {
          if (_context.TransferMethodIndices == null)
          {
              return Problem("Entity set 'DefaultDbContext.TransferMethodIndices'  is null.");
          }
            _context.TransferMethodIndices.Add(transferMethodIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransferMethodIndex", new { id = transferMethodIndex.Id }, transferMethodIndex);
        }

        // DELETE: v1//[controller]ransferMethodIndex/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransferMethodIndex(int id)
        {
            if (_context.TransferMethodIndices == null)
            {
                return NotFound();
            }
            var transferMethodIndex = await _context.TransferMethodIndices.FindAsync(id);
            if (transferMethodIndex == null)
            {
                return NotFound();
            }

            _context.TransferMethodIndices.Remove(transferMethodIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransferMethodIndexExists(int id)
        {
            return (_context.TransferMethodIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




