using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportService.DataAccess;
using TransportService.Model;

namespace AdhiSreeTransportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleAlertsApiController : ControllerBase
    {
        private readonly TransportServiceDBContext _context;

        public VehicleAlertsApiController(TransportServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/VehicleAlerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleAlerts>>> GetVehicleAlerts()
        {
            return await _context.VehicleAlerts
                .Include(v => v.Vehicle)
                .ToListAsync();
        }

        // GET: api/VehicleAlerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleAlerts>> GetVehicleAlert(int id)
        {
            var vehicleAlert = await _context.VehicleAlerts
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleAlert == null)
            {
                return NotFound();
            }

            return vehicleAlert;
        }

        // GET: api/VehicleAlerts/Vehicle/1
        [HttpGet("Vehicle/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<VehicleAlerts>>> GetAlertsByVehicle(short vehicleId)
        {
            var alerts = await _context.VehicleAlerts
                .Include(v => v.Vehicle)
                .Where(v => v.VehicleId == vehicleId)
                .ToListAsync();

            return alerts;
        }

        // POST: api/VehicleAlerts
        [HttpPost]
        public async Task<ActionResult<VehicleAlerts>> CreateVehicleAlert(VehicleAlerts vehicleAlert)
        {
            var vehicleExists = await _context.Vehicle
                .AnyAsync(v => v.ID == vehicleAlert.VehicleId);

            if (!vehicleExists)
            {
                return BadRequest($"Vehicle with Id {vehicleAlert.VehicleId} not found.");
            }

            _context.VehicleAlerts.Add(vehicleAlert);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetVehicleAlert),
                new { id = vehicleAlert.Id },
                vehicleAlert);
        }

        // PUT: api/VehicleAlerts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleAlert(int id, VehicleAlerts vehicleAlert)
        {
            if (id != vehicleAlert.Id)
            {
                return BadRequest("Id mismatch.");
            }

            var vehicleExists = await _context.Vehicle
                .AnyAsync(v => v.ID == vehicleAlert.VehicleId);

            if (!vehicleExists)
            {
                return BadRequest($"Vehicle with Id {vehicleAlert.VehicleId} not found.");
            }

            _context.Entry(vehicleAlert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleAlertExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/VehicleAlerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAlert(int id)
        {
            var vehicleAlert = await _context.VehicleAlerts
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleAlert == null)
            {
                return NotFound();
            }

            _context.VehicleAlerts.Remove(vehicleAlert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleAlertExists(int id)
        {
            return _context.VehicleAlerts.Any(e => e.Id == id);
        }
    }
}