using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class WindowsCoreIdentityController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public WindowsCoreIdentityController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/WindowsCoreIdentity
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentities()
        {
          if (_context.WindowsCoreIdentities == null)
          {
              return NotFound();
          }
            return await _context.WindowsCoreIdentities.ToListAsync();
        }

        // // GET: v1/WindowsCoreIdentity/5
        // [EnableCors("MyAllowAllOrigins")]
        //[HttpGet("{id:int}")]
        // public async Task<ActionResult<WindowsCoreIdentity>> GetWindowsCoreIdentity(int id)
        // {
        //   if (_context.WindowsCoreIdentities == null)
        //   {
        //       return NotFound();
        //   }
        //     var windowsCoreIdentity = await _context.WindowsCoreIdentities.FindAsync(id);

        //     if (windowsCoreIdentity == null)
        //     {
        //         return NotFound();
        //     }

        //     return windowsCoreIdentity;
        // }

        // GET: v1//WindowsCoreIdentity/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WindowsCoreIdentity>> GetWindowsCoreIdentity(int id)
        {
            var windowsCoreIdentity = await _context.WindowsCoreIdentities.FindAsync(id);

            if (windowsCoreIdentity == null)
            {
                var result = new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = String.Empty,
                    Edition = String.Empty,
                    Version = String.Empty,
                    Build = String.Empty,
                    Arch = String.Empty,
                    WindowsLcid = String.Empty,
                    SupportedUntil = String.Empty,
                };
                
                //return NotFound();
                return result;
            }

            return windowsCoreIdentity;
        }

        // PUT: v1/WindowsCoreIdentity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutWindowsCoreIdentity(int id, WindowsCoreIdentity windowsCoreIdentity)
        {
            if (id != windowsCoreIdentity.Id)
            {
                return BadRequest();
            }

            _context.Entry(windowsCoreIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WindowsCoreIdentityExists(id))
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

        // POST: v1/WindowsCoreIdentity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<WindowsCoreIdentity>> PostWindowsCoreIdentity(WindowsCoreIdentity windowsCoreIdentity)
        {
          if (_context.WindowsCoreIdentities == null)
          {
              return Problem("Entity set 'DefaultDbContext.WindowsCoreIdentities'  is null.");
          }
            _context.WindowsCoreIdentities.Add(windowsCoreIdentity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindowsCoreIdentity", new { id = windowsCoreIdentity.Id }, windowsCoreIdentity);
        }

        // DELETE: v1/WindowsCoreIdentity/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWindowsCoreIdentity(int id)
        {
            if (_context.WindowsCoreIdentities == null)
            {
                return NotFound();
            }
            var windowsCoreIdentity = await _context.WindowsCoreIdentities.FindAsync(id);
            if (windowsCoreIdentity == null)
            {
                return NotFound();
            }

            _context.WindowsCoreIdentities.Remove(windowsCoreIdentity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WindowsCoreIdentityExists(int id)
        {
            return (_context.WindowsCoreIdentities?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1//WindowsCoreIdentity/uuid/{uuid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("uuid/{uuid}")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByUUid([FromRoute]string uuid)
        {
            var windowscoreidentities = _context.WindowsCoreIdentities.Where(a => a.UUID.ToString() == uuid);
            
            if (windowscoreidentities.Count() == 0)
            {
                return NotFound();
            }

            return await windowscoreidentities.ToListAsync();
        }

        // GET: v1//WindowsCoreIdentity/uid/{uid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("uid/{uid}")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByUid([FromRoute]string uid)
        {
            var windowscoreidentities = _context.WindowsCoreIdentities.Where(a => a.UID == uid.ToLower());
            
            if (windowscoreidentities.Count() == 0)
            {
                return NotFound();
            }

            return await windowscoreidentities.ToListAsync();
        }

        // GET: v1//WindowsCoreIdentity/release/Windows7
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("release/windows7")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseWindows7()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Release == "Windows 7").ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Windows81
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("release/windows81")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseWindows81()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Release == "Windows 8.1").ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Windows10
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("release/windows10")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseWindows10()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Release == "Windows 10").ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Windows11
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("release/Windows11")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseWindows11()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Release == "Windows 11").ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/arch/x86
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("arch/x86")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByArchX86()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Arch.Contains("x86")).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/arch/x64
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("arch/x64")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByArchX64()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.Arch.Contains("x64")).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Arabic
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Arabic")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseArabic()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("ar"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Brazilian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Brazilian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseBrazilian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("pt-BR"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Bulgarian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Bulgarian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseBulgarian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("bg"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Chinese
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Chinese")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseChinese()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("zh"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Chinese Traditional
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Chinese_Traditional")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseChineseTraditional()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("zh-CN"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Croatian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Croatian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseCroatian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("hr"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Czech
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Czech")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseCzech()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("cs"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Danish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Danish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseDanish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("da"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Dutch
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Dutch")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseDutch()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("nl"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/English
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/English")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseEnglish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.WindowsLcid.Contains("en-US")).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/English International
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/English_International")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseEnglishInternational()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => a.WindowsLcid.Contains("en-UK")).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Estonian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Estonian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseEstonian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("et"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Finnish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Finnish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseFinnish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("fi"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/French
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/French")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseFrench()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("fr"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/French Canadian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/French_Canadian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseFrenchCanadian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("fr-CA"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/German
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/German")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseGerman()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("de"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Greek
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Greek")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseGreek()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("el"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Hebrew
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Hebrew")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseHebrew()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("he"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Hungarian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Hungarian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseHungarian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("hu"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Italian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Italian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseItalian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("it"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Japanese
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Japanese")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseJapanese()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("ja"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Korean
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Korean")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseKorean()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("ko"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Latvian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Latvian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseLatvian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("lv"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Lithuanian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Lithuanian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseLithuanian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("lt"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Norwegian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Norwegian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseNorwegian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("no"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Polish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Polish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleasePolish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("po"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Portuguese
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Portuguese")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleasePortuguese()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("pt"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Romanian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Romanian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseRomanian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("ro"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Russian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Russian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseRussian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("ru"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Serbian Latin
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Serbian_Latin")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSerbianLatin()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("sr"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Slovak
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Slovak")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSlovak()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("sk"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Slovenian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Slovenian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSlovenian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("sl"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Spanish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Spanish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSpanish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("es"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Spanish Latam
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Spanish_Latam")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSpanishLatam()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("es-LA"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Swedish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Swedish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseSwedish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("sv"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Thai
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Thai")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseThai()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("th"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Turkish
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Turkish")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseTurkish()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("tr"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }

        // GET: v1//WindowsCoreIdentity/release/Ukrainian
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/Ukrainian")]
        public async Task<ActionResult<IEnumerable<WindowsCoreIdentity>>> GetWindowsCoreIdentityByReleaseUkrainian()
        {
            List<WindowsCoreIdentity> tmpList = new();
            var list = await _context.WindowsCoreIdentities.Where(a => 
                (a.WindowsLcid.Contains("Intl")) || 
                (a.WindowsLcid.Contains("uk"))
            ).ToListAsync();
            if (list.Count < 1)
            {
                tmpList.Add(new WindowsCoreIdentity
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    UID = "No Results",
                    Release = "",
                    Edition = "",
                    Version = "",
                    Build = "",
                    Arch = "",
                    WindowsLcid = "",
                    SupportedUntil = "",
                });
                return tmpList;
            }
            else
            {
                return list;
            }
        }
    }
}





