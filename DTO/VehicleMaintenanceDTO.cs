namespace TransportService.Model
{
public class VehicleMaintenanceDTO
{
    
    public int Id { get; set; }

    public required short VehicleId { get; set; }

    public required short DriverId { get; set; }

    public required DateOnly MaintenanceDate { get; set; }

    public required decimal Kilometers { get; set; }

    public required decimal Cost { get; set; }

    public required string Description { get; set; } = string.Empty;

    
}
}   