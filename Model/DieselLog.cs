using System.ComponentModel.DataAnnotations.Schema;
using TransportService.Model;

public class DieselLog
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerUnit { get; set; }

    public int SourceId { get; set; } // 0 for own, 1 for external

    public decimal OdometerReading { get; set; }

    public string? Remarks { get; set; }
    


    [ForeignKey("SourceId") ]
    public required Party Source { get; set; } // Navigation property to Party



    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCost { get; set; }

    [ForeignKey("VehicleId")]
    public required Vehicle Vehicle { get; set; } // Navigation property to Vehicle

}

