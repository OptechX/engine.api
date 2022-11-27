using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;
using Stackoverflow.Answers.Helpers;
using api.engine_v2.Models.Shared.Enums;
using api.engine_v2.Models.Engine.Enums;
using Microsoft.AspNetCore.Cors;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BaseImageController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public BaseImageController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/BaseImage
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseImage>>> GetBaseImages()
        {
          if (_context.BaseImages == null)
          {
              return NotFound();
          }
            return await _context.BaseImages.ToListAsync();
        }

        // GET: v1/BaseImage/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
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

        // PUT: v1/BaseImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
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

        // POST: v1/BaseImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
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

        // DELETE: v1/BaseImage/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
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

        // GET: v1//BaseImage/release/{release}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("release/{release}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByRelease([FromRoute]string release)
        {
            var images = _context.BaseImages.Where(a => a.Release == release);
            // var images = _context.BaseImages.Where(a => a.Release == EnumExtensions.GetValueFromEnumMember<WindowsRelease>(release));

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/edition/{edition}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("edition/{edition}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByEdition([FromRoute]string edition)
        {
            var images = _context.BaseImages.Where(a => a.Edition.Contains(edition));
            // var images = _context.BaseImages.Where(a => a.Edition == EnumExtensions.GetValueFromEnumMember<WindowsEdition>(edition));

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/version/{version}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("version/{version}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByVersion([FromRoute]string version)
        {
            var images = _context.BaseImages.Where(a => a.Version == version);
            // var images = _context.BaseImages.Where(a => a.Version == EnumExtensions.GetValueFromEnumMember<WindowsVersion>(version));

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/cpuarch/{cpuarch}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("cpuarch/{cpuarch}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByCpuArch([FromRoute]string cpuarch)
        {
            var images = _context.BaseImages.Where(a => a.CpuArch == cpuarch);

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/baseimagefiletype/{filetype}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("baseimagefiletype/{filetype}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByBaseImageFileType([FromRoute]string filetype)
        {
            var images = _context.BaseImages.Where(a => a.BaseImageFileType.ToString() == EnumExtensions.GetValueFromEnumMember<BaseImageFileType>(filetype).ToString());

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/windowslcid/{windowslcid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("windowslcid/{windowslcid}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByWindowsLcid([FromRoute]string windowslcid)
        {
            var images = _context.BaseImages.Where(a => a.WindowsLcid.Contains(windowslcid));

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/locale/{locale}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("locale/{locale}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByLocale([FromRoute]string locale)
        {
            var images = _context.BaseImages.Where(a => a.Locale == locale);
            // var images = _context.BaseImages.Where(a => a.Locale == EnumExtensions.GetValueFromEnumMember<Locale>(locale));

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        // GET: v1//BaseImage/transfermethod/{method}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("transfermethod/{method}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByTransferMethod([FromRoute]string method)
        {
            var images = _context.BaseImages.Where(a => a.TransferMethod.ToString() == EnumExtensions.GetValueFromEnumMember<api.engine_v2.Models.Engine.Enums.TransferMethod>(method).ToString());

            if (images.Count() == 0)
            {
                return NotFound();
            }

            return await images.ToListAsync();
        }

        //GET: v1//BaseImage/multisearch/{release}/{edition}/{version}/{cpuarch}/{windowslcid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("multisearch/{release}/{edition}/{version}/{cpuarch}/{windowslcid}")]
        public async Task<ActionResult<IEnumerable<BaseImage>>> BaseImageByMultiSearch([FromRoute]string release, string edition, string version, string cpuarch, string windowslcid)
        {
            var images = _context.BaseImages.Where(a =>
                a.Release.Contains(release) &&
                a.Edition.Contains(edition) &&
                a.Version.Contains(version) &&
                a.CpuArch == cpuarch &&
                a.WindowsLcid.Contains(windowslcid));
            if (images.Count() == 0)
            {
                return NotFound();
            }
            return await images.ToListAsync();
        }
    }
}





