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
    public class OrderManagementController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public OrderManagementController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1OrderManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagements()
        {
          if (_context.OrderManagements == null)
          {
              return NotFound();
          }
            return await _context.OrderManagements.ToListAsync();
        }

        // GET: v1OrderManagement/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderManagement>> GetOrderManagement(int id)
        {
          if (_context.OrderManagements == null)
          {
              return NotFound();
          }
            var orderManagement = await _context.OrderManagements.FindAsync(id);

            if (orderManagement == null)
            {
                return NotFound();
            }

            return orderManagement;
        }

        // PUT: v1OrderManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutOrderManagement(int id, OrderManagement orderManagement)
        {
            if (id != orderManagement.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderManagementExists(id))
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

        // POST: v1OrderManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderManagement>> PostOrderManagement(OrderManagement orderManagement)
        {
          if (_context.OrderManagements == null)
          {
              return Problem("Entity set 'DefaultDbContext.OrderManagements'  is null.");
          }
            _context.OrderManagements.Add(orderManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderManagement", new { id = orderManagement.Id }, orderManagement);
        }

        // DELETE: v1OrderManagement/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderManagement(int id)
        {
            if (_context.OrderManagements == null)
            {
                return NotFound();
            }
            var orderManagement = await _context.OrderManagements.FindAsync(id);
            if (orderManagement == null)
            {
                return NotFound();
            }

            _context.OrderManagements.Remove(orderManagement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderManagementExists(int id)
        {
            return (_context.OrderManagements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


