using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportService.DataAccess;

namespace AdhiSreeTransportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DieselLogApiController : ControllerBase
    {
        private readonly TransportServiceDBContext _context;

        public DieselLogApiController(TransportServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/DieselLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DieselLog>>> GetDieselLogs()
        {
            return await _context.DieselLogs.ToListAsync();
        }

        // GET: api/DieselLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DieselLog>> GetDieselLog(int id)
        {
            var dieselLog = await _context.DieselLogs.FindAsync(id);

            if (dieselLog == null)
            {
                return NotFound();
            }

            return dieselLog;
        }

        // POST: api/DieselLog
        [HttpPost]
        public async Task<ActionResult<DieselLog>> PostDieselLog(DieselLog dieselLog)
        {
            _context.DieselLogs.Add(dieselLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDieselLog), new { id = dieselLog.Id }, dieselLog);
        }

        // PUT: api/DieselLog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDieselLog(int id, DieselLog dieselLog)
        {
            if (id != dieselLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(dieselLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DieselLogExists(id))
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

        // DELETE: api/DieselLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDieselLog(int id)
        {
            var dieselLog = await _context.DieselLogs.FindAsync(id);
            if (dieselLog == null)
            {
                return NotFound();
            }

            _context.DieselLogs.Remove(dieselLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DieselLogExists(int id)
        {
            return _context.DieselLogs.Any(e => e.Id == id);
        }
    }
}