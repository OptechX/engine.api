using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Data;
using api.engine_v2.Models.Engine;
using Stackoverflow.Answers.Helpers;
using api.engine_v2.Models.Engine.Enums;
using Microsoft.AspNetCore.Cors;

namespace api.engine_v2.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public ApplicationController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: v1/Application
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
          if (_context.Applications == null)
          {
              return NotFound();
          }
            return await _context.Applications.ToListAsync();
        }

        // GET: v1/Application/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
          if (_context.Applications == null)
          {
              return NotFound();
          }
            var application = await _context.Applications.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: v1/Application/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: v1/Application
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("MyAllowAllOrigins")]
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
          if (_context.Applications == null)
          {
              return Problem("Entity set 'DefaultDbContext.Applications'  is null.");
          }
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: v1/Application/5
        [EnableCors("MyAllowAllOrigins")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(int id)
        {
            return (_context.Applications?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: v1//application/uid/{uid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("uid/{uid}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByUid([FromRoute] string uid)
        {
            //var applications = _context.Applications.Where(a => a.UID.Contains(uid));  //<- partial match
            var applications = _context.Applications.Where(a => a.UID == uid);           //<- exact match

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }


        // GET: v1//application/applicationcategory/{category}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByCategory([FromRoute] string category)
        {
            //var applications = _context.Applications.Where(a => a.CpuArchId.Contains(cpuarchid));  //<- partial match
            //var applications = _context.Applications.Where(a => a.ApplicationCategory.ToString() == category);  //<- exact match

            var applications = _context.Applications.Where(a => a.ApplicationCategory == EnumExtensions.GetValueFromEnumMember<ApplicationCategory>(category));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1//application/publisher/{publisher}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("publisher/{publisher}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByPublisher([FromRoute] string publisher)
        {
            var applications = _context.Applications.Where(a => a.Publisher.Contains(publisher));  //<- partial match
            //var applications = _context.Applications.Where(a => a.Publisher == publisher);       //<- exact match

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1//application/name/{name}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByName([FromRoute] string name)
        {
            var applications = _context.Applications.Where(a => a.Name.Contains(name));  //<- partial match
            //var applications = _context.Applications.Where(a => a.Name == name);       //<- exact match

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1//application/cpuarch/{cpuarch}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("arch/{arch}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByCpuArch([FromRoute] string arch)
        {
            var applications = _context.Applications.Where(a => a.CpuArch.Contains(arch));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1//application/lcid/{lcid}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("lcid/{lcid}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByLcid([FromRoute] string lcid)
        {
            var applications = _context.Applications.Where(a => a.Lcid.Contains(lcid));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1//application/tags/{tags}
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("tags/{tag}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByTags([FromRoute] string tag)
        {
            var applications = _context.Applications.Where(a => a.Tags.Contains(tag.ToLower()));

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }

        // GET: v1/Application/last5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("last5")]
        public async Task<ActionResult<IEnumerable<ApplicationLast5>>> Get5Applications()
        {
            List<ApplicationLast5> tmpList = new();

            var list = await _context.Applications.ToListAsync();


            for (int i = Math.Max(0, list.Count - 5); i < list.Count; ++i)
            {
                tmpList.Add(new ApplicationLast5
                {
                    Name = list[i].Name,
                    Version = list[i].Version,
                    Publisher = list[i].Publisher,
                });
            }
            var ordersArray = tmpList.ToArray();

            return tmpList;
        }

        // GET: v1/Application/last5
        [EnableCors("MyAllowAllOrigins")]
        [HttpGet("{publisher}/{name}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationByPublisherName([FromRoute]string publisher, [FromRoute]string name)
        {
            var applications = _context.Applications.Where(a => 
                                    a.Publisher.Contains(publisher) &&
                                    a.Name.Contains(name)
                                );  //<- partial match

            if (applications.Count() == 0)
            {
                return NotFound();
            }

            return await applications.ToListAsync();
        }
    }
}
