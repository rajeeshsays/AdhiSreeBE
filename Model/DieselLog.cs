using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportService.Model;

public class DieselLog
{
    [Key]
    public int Id { get; set; }

    public short VehicleId { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerUnit { get; set; }

    public short SourceId { get; set; } // 0 for own, 1 for external

    public int OdometerReading { get; set; }

    public string? Remarks { get; set; }

    public short DriverId { get; set; }

    [ForeignKey("SourceId") ]
    public virtual Party? Source { get; set; } // Navigation property to Party



    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCost { get; set; }

    [ForeignKey("VehicleId")]
    public  virtual Vehicle? Vehicle { get; set; } // Navigation property to Vehicle

}

