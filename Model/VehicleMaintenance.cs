using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TransportService.Model
{
public class VehicleMaintenance
{
    [Key]
    public int Id { get; set; }

    public required short VehicleId { get; set; }

    public required short DriverId { get; set; }

    public required DateOnly MaintenanceDate { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public required decimal Kilometers { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public required decimal Cost { get; set; }

    public required string Description { get; set; } = string.Empty;

    [ForeignKey("VehicleId")]
    public  Vehicle? Vehicle { get; set; } // Navigation property to Vehicle
    
    [ForeignKey("DriverId")]
    public  Driver? Driver { get; set; } // Navigation property to Driver

}
}   