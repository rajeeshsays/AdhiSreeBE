using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace TransportService.Model
{
    [Table("DriverLedgers")]
    public class DriverLedger
    {
        [Key]
        public short ID { get; set; }

        public DateOnly TransactionDate { get; set; }
        public short DriverId { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }


        [ForeignKey("DriverId")]
        public Driver? Driver { get; set; } // Navigation property to Driver

        public string Remarks { get; set; } = string.Empty;

    }

    
}
