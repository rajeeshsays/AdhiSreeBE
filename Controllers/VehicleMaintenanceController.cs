using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportService.DataAccess;
using TransportService.Model;

namespace AdhiSreeTransportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMaintenanceApiController : ControllerBase
    {
        private readonly TransportServiceDBContext _context;

        public VehicleMaintenanceApiController(TransportServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/VehicleMaintenance
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<VehicleMaintenance>>> GetAll()
        {
            try
            {
            var x =  await _context.VehicleMaintenance
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .OrderByDescending(x => x.MaintenanceDate)
                .ToListAsync();
            var y = x;
            return Ok(y);
            }
            catch(Exception ex)
            {
                var x=ex;
                return BadRequest();
            }
             return BadRequest();
        }

        // GET: api/VehicleMaintenance/5
        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<VehicleMaintenance>> GetById(int id)
        {
            var maintenance = await _context.VehicleMaintenance
                .Include(x => x.Vehicle)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maintenance == null)
                return NotFound();

            return Ok(maintenance);
        }

        // GET: api/VehicleMaintenance/Vehicle/1
        [HttpGet("Vehicle/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<VehicleMaintenance>>> GetByVehicle(short vehicleId)
        {
            var records = await _context.VehicleMaintenance
                .Include(x => x.Vehicle)
                .Where(x => x.VehicleId == vehicleId)
                .OrderByDescending(x => x.MaintenanceDate)
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/VehicleMaintenance
        [HttpPost("create")]
        public async Task<ActionResult<VehicleMaintenance>> Create([FromBody] VehicleMaintenanceDTO maintenanceDto)
        {

            var maintenance = new VehicleMaintenance
            {
                Id=0,
                MaintenanceDate = maintenanceDto.MaintenanceDate,
                VehicleId = maintenanceDto.VehicleId,
                DriverId = maintenanceDto.DriverId,
                Kilometers = maintenanceDto.Kilometers,
                Cost = maintenanceDto.Cost,
                Description = maintenanceDto.Description,
                
            };


           

            _context.VehicleMaintenance.Add(maintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = maintenance.Id },
                maintenance);
        }

        // PUT: api/VehicleMaintenance/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, VehicleMaintenance maintenance)
        {
            if (id != maintenance.Id)
                return BadRequest("Id mismatch.");

            var existing = await _context.VehicleMaintenance
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                return NotFound();

            existing.VehicleId = maintenance.VehicleId;
            existing.DriverId = maintenance.DriverId;
            existing.MaintenanceDate = maintenance.MaintenanceDate;
            existing.Kilometers = maintenance.Kilometers;
            existing.Cost = maintenance.Cost;
            existing.Description = maintenance.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/VehicleMaintenance/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var maintenance = await _context.VehicleMaintenance
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maintenance == null)
                return NotFound();

            _context.VehicleMaintenance.Remove(maintenance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleMaintenanceExists(int id)
        {
            return _context.VehicleMaintenance.Any(x => x.Id == id);
        }
    }
}