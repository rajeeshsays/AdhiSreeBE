using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Caching.Memory;
//using TransportService.DA;
using TransportService.DataAccess;
using TransportService.Model;
using TransportService.DTO;

namespace TransportService.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLedgerApiController : ControllerBase
    {
        // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
        private readonly IConfiguration? _config;
        private readonly IMemoryCache? _cache;
        private readonly TransportServiceDBContext _context;


        public DriverLedgerApiController(IConfiguration? config, IMemoryCache? cache, TransportServiceDBContext context)
        {
            _config = config;
            _cache = cache;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var x = await _context.DriverLedgers.ToListAsync();
           var ledger = await _context.DriverLedgers.Where(x => x.DriverId == id)                                  
              .ToListAsync();

           if (ledger != null)
           {
               return Ok(ledger);
           }
           else
           {
               return NotFound();
           }
        }

       [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DriverLedger driverLedger)
        {
           if (driverLedger == null)
               return BadRequest("Invalid driver ledger data.");
           try
           {
               await _context.DriverLedgers.AddAsync(driverLedger);  
               await _context.SaveChangesAsync();
               return Ok("Driver ledger created successfully");
           }
           catch (Exception ex)
           {
               return StatusCode(500, "Failed to create the driver ledger record.");
           }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] DriverLedger driverEntryForUpdate)
        {
           if (driverEntryForUpdate == null)
               return BadRequest("Invalid driver ledger data.");
           try
           {
               _context.Entry(driverEntryForUpdate).State = EntityState.Modified;
               await _context.SaveChangesAsync();
               return Ok("Driver ledger record updated");
           }
           catch (DbUpdateConcurrencyException)
           {
               return StatusCode(StatusCodes.Status500InternalServerError, "A concurrency error occurred");

           }
           catch (DbUpdateException)
           {
               return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update driver ledger.");

           }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
          
           try
            {
                var driverLedger = await _context.DriverLedgers.FindAsync(id);
                if (driverLedger == null)
                {
                    return NotFound(); // 404
                }
                _context.Entry(driverLedger).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return NoContent(); // 204
            }
            catch(Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to delete driver ledger. Error: {ex.Message}");
               
            }
 
        }
    }
}

 