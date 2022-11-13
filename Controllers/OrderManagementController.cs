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
        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<OrderManagement>> GetOrderManagement(int id)
        //{
        //  if (_context.OrderManagements == null)
        //  {
        //      return NotFound();
        //  }
        //    var orderManagement = await _context.OrderManagements.FindAsync(id);

        //    if (orderManagement == null)
        //    {
        //        return NotFound();
        //    }

        //    return orderManagement;
        //}

        // GET: v1/OrderManagement/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderManagement>> GetOrderManagement(int id)
        {
            var OrderManagement = await _context.OrderManagements.FindAsync(id);

            if (OrderManagement == null)
            {
                var result = new OrderManagement
                {
                    Id = 0,
                    UUID = Guid.Empty,
                    AccountId = 0,
                    OrderDate = null,
                    OrderStatus = "Deleted",
                    OrderName = "Not Found",
                    DownloadLink = null,
                    ImageOutputFormat = null,
                    NotificationEmailAddress = null,
                    ContinuousIntegration = false,
                    ContinuousDelivery = false,
                    Release = null,
                    Edition = null,
                    Version = null,
                    Arch = null,
                    Lcid = null,
                    OptionalFeatureString = null,
                    AppxPackagesString = null,
                    WindowsDefaultAccount = null,
                    WindowsDefaultPassword = "xxxxxxxx",
                    CustomRegistryKeys = null,
                    ApplicationUID = null,
                    DriversUID = null,
                };

                return result;
            }

            return OrderManagement;
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

        // GET: v1/OrderManagement/uuid/{uuid}
        [HttpGet("uuid/{uuid}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByUUID([FromRoute] string uuid)
        {
            var orders = _context.OrderManagements.Where(a => a.UUID.ToString() == uuid.ToString());

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/byaccountid
        [HttpGet("byaccountid/{accountid:int}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByAccountId([FromRoute] int accountid)
        {
            var orders = _context.OrderManagements.Where(a => a.AccountId.ToString() == accountid.ToString());

            if (orders.Count() == 0)
            {
                var result = new List<OrderManagement>()
                {
                    new OrderManagement {
                        Id = 0,
                        UUID = Guid.Empty,
                        AccountId = 0,
                        OrderDate = null,
                        OrderStatus = "Deleted",
                        OrderName = "Not Found",
                        DownloadLink = null,
                        ImageOutputFormat = null,
                        NotificationEmailAddress = null,
                        ContinuousIntegration = false,
                        ContinuousDelivery = false,
                        Release = null,
                        Edition = null,
                        Version = null,
                        Arch = null,
                        Lcid = null,
                        OptionalFeatureString = null,
                        AppxPackagesString = null,
                        WindowsDefaultAccount = null,
                        WindowsDefaultPassword = "xxxxxxxx",
                        CustomRegistryKeys = null,
                        ApplicationUID = null,
                        DriversUID = null,
                    },
                };

                return result;
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/orderstatus/{orderstatus}
        [HttpGet("orderstatus/{orderstatus}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByOrderStatus([FromRoute] string orderstatus)
        {
            var orders = _context.OrderManagements.Where(a => a.OrderStatus == orderstatus);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/ordername/{ordername}
        [HttpGet("ordername/{ordername}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByOrderName([FromRoute] string ordername)
        {
            var orders = _context.OrderManagements.Where(a => a.OrderName.ToUpper() == ordername.ToUpper());

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/release/{release}
        [HttpGet("release/{release}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByRelease([FromRoute] string release)
        {
            //var orders = _context.OrderManagements.Where(a => a.Release == EnumExtensions.GetValueFromEnumMember<WindowsRelease>(release));
            var orders = _context.OrderManagements.Where(a => a.Release == release);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/edition/{edition}
        [HttpGet("edition/{edition}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByEdition([FromRoute] string edition)
        {
            //var orders = _context.OrderManagements.Where(a => a.Edition == EnumExtensions.GetValueFromEnumMember<WindowsEdition>(edition));
            var orders = _context.OrderManagements.Where(a => a.Edition == edition);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/version/{version}
        [HttpGet("version/{version}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByVersion([FromRoute] string version)
        {
            //var orders = _context.OrderManagements.Where(a => a.Version == EnumExtensions.GetValueFromEnumMember<WindowsVersion>(version));
            var orders = _context.OrderManagements.Where(a => a.Version == version);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/arch/{arch}
        [HttpGet("arch/{arch}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByArch([FromRoute] string arch)
        {
            //var orders = _context.OrderManagements.Where(a => a.Arch == EnumExtensions.GetValueFromEnumMember<CpuArch>(arch));
            var orders = _context.OrderManagements.Where(a => a.Arch == arch);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/lcid/{lcid}
        [HttpGet("lcid/{lcid}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementByLcid([FromRoute] string lcid)
        {
            var orders = _context.OrderManagements.Where(a => a.Lcid == lcid);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/usesapplicationuid/{applicationuid}
        [HttpGet("usesapplicationuid/{applicationuid}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementUsingApplicationUID([FromRoute] string applicationuid)
        {
            var orders = _context.OrderManagements.Where(a => a.ApplicationUID.Contains(applicationuid));

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/usesdriversuid/{driversuid}
        [HttpGet("usesdriversuid/{driversuid}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementUsingDriversUID([FromRoute] string driversuid)
        {
            var orders = _context.OrderManagements.Where(a => a.DriversUID.Contains(driversuid));

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/cd-enabled
        [HttpGet("cd-enabled")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementCDEnabled()
        {
            var orders = _context.OrderManagements.Where(a => a.ContinuousDelivery == true);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/ci-enabled
        [HttpGet("ci-enabled")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementCIEnabled()
        {
            var orders = _context.OrderManagements.Where(a => a.ContinuousIntegration == true);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/ci-cd-enabled
        [HttpGet("ci-cd-enabled")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> GetOrderManagementCICDEnabled()
        {
            var orders = _context.OrderManagements.Where(a =>
                a.ContinuousIntegration == true &&
                a.ContinuousDelivery == true);

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/deleteorderbyid/5
        [HttpGet("deleteorderbyid/{id:int}")]
        public async Task<ActionResult<IEnumerable<OrderManagement>>> SetOrderManagementDeleted([FromRoute] int id)
        {
            var OrderManagement = await _context.OrderManagements.FindAsync(id);

            if (OrderManagement == null)
            {
                return NotFound();
            }

            // update status of current request first
            OrderManagement.OrderStatus = "Deleted";
            await _context.SaveChangesAsync();

            // current customer number
            int currentCustomer = OrderManagement.AccountId;

            // get list of all orders now status is updated
            var orders = _context.OrderManagements.Where(a => a.AccountId.ToString() == currentCustomer.ToString());

            // return found objects
            return await orders.ToListAsync();
        }

        // GET: v1/OrderManagement/byaccountid-last5/{accountid:int}
        [HttpGet("byaccountid-last5/{accountid:int}")]
        public async Task<ActionResult<IEnumerable<OrderManagement5Items>>> GetOrderManagementByAccountIdLast5([FromRoute] int accountid)
        {
            // create a blank result to return, of the new introduced mini type
            var result = new List<OrderManagement5Items>();

            // get all the orders matching the account Id
            var orders = _context.OrderManagements.Where(a => a.AccountId.ToString() == accountid.ToString());

            // if there are no orders, create a blank order to return
            if (orders.Count() == 0)
            {
                result.Add(new OrderManagement5Items
                {
                    OrderName = "No Current Orders",
                    Date = "",
                    Status = "",
                });
            }

            if (orders.Count() > 5)
            {
                List<OrderManagement5Items> tmpList = new();

                // get all orders not Deleted
                foreach (var o in orders)
                {
                    if (String.Compare(o.OrderStatus, "Complete") == 0 || (String.Compare(o.OrderStatus, "Compiling")) == 0 || (String.Compare(o.OrderStatus, "Submitted")) == 0)
                    {
                        tmpList.Add(new OrderManagement5Items
                        {
                            OrderName = o.OrderName,
                            Date = o.OrderDate,
                            Status = o.OrderStatus,
                        });
                    }
                }

                // total number of items in tmpList ?
                int totalTmpListCount = tmpList.Count();

                // create an array (easier to work with)
                var ordersArray = tmpList.ToArray();

                for (int i = 5; i > 0; i--)
                {
                    result.Add(new OrderManagement5Items
                    {
                        OrderName = ordersArray[totalTmpListCount - i].OrderName,
                        Date = ordersArray[totalTmpListCount - i].Date,
                        Status = ordersArray[totalTmpListCount - i].Status,
                    });
                }
            }

            // if there are more than 0 orders, add them to the array, so long as they aren't "Deleted"
            if (orders.Count() < 6 && orders.Count() > 0)
            {
                foreach (var o in orders)
                {
                    if (String.Compare(o.OrderStatus, "Complete") == 0 || (String.Compare(o.OrderStatus, "Compiling")) == 0 || (String.Compare(o.OrderStatus, "Submitted")) == 0)
                    {
                        result.Add(new OrderManagement5Items
                        {
                            OrderName = o.OrderName,
                            Date = o.OrderDate,
                            Status = o.OrderStatus,
                        });
                        await Task.Delay(1);
                    }
                }
            }

            // if the returned array is still blank (ie - the only returned order was Deleted), create a blank order
            if (result.Count < 1)
            {
                result.Add(new OrderManagement5Items
                {
                    OrderName = "No Current Orders",
                    Date = "",
                    Status = "",
                });
            }

            return result;
        }
    }
}


