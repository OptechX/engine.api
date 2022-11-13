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
    public class BaseImageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public BaseImageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1BaseImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseImage>>> GetBaseImages()
        {
          if (_context.BaseImages == null)
          {
              return NotFound();
          }
            return await _context.BaseImages.ToListAsync();
        }

        // GET: v1BaseImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseImage>> GetBaseImage(int id)
        {
          if (_context.BaseImages == null)
          {
              return NotFound();
          }
            var baseImage = await _context.BaseImages.FindAsync(id);

            if (baseImage == null)
            {
                return NotFound();
            }

            return baseImage;
        }

        // PUT: v1BaseImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseImage(int id, BaseImage baseImage)
        {
            if (id != baseImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseImageExists(id))
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

        // POST: v1BaseImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseImage>> PostBaseImage(BaseImage baseImage)
        {
          if (_context.BaseImages == null)
          {
              return Problem("Entity set 'DefaultDbContext.BaseImages'  is null.");
          }
            _context.BaseImages.Add(baseImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseImage", new { id = baseImage.Id }, baseImage);
        }

        // DELETE: v1BaseImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseImage(int id)
        {
            if (_context.BaseImages == null)
            {
                return NotFound();
            }
            var baseImage = await _context.BaseImages.FindAsync(id);
            if (baseImage == null)
            {
                return NotFound();
            }

            _context.BaseImages.Remove(baseImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseImageExists(int id)
        {
            return (_context.BaseImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

