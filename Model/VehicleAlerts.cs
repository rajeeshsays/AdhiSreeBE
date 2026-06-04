
//Vehicle complains



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportService.Model;

public class VehicleAlerts
{
    [Key]
    public int Id { get; set; }

    public int VehicleId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Emi { get; set; }
    
    public DateOnly EmiDueDate { get; set; }

    public int EmiDaysLeft { get; set; }

    [Required]
    public DateOnly InsuranceExpiry   { get; set; }


    public int InsuranceDaysLeft { get; set; }

    [Required]
    public int InsuranceStatus { get; set; }


    [Required]
    public DateOnly PollutionExpiry { get; set; } 


    public int PollutionDaysLeft { get; set; }


    [Required]
    public int PollutionStatus { get; set; }

    public string? FuelStationName { get; set; }

    public string? Remarks { get; set; }
    

    [ForeignKey("VehicleId")]
    public required Vehicle Vehicle { get; set; } // Navigation property to Vehicle
    
}




