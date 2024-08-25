using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required, MaxLength(50)]
        public string Make { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required, MaxLength(17)]
        public string VIN { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        // Navigation Property
        public Customer Customer { get; set; }

        // Navigation Property for Service Records
        public ICollection<ServiceRecord> ServiceRecords { get; set; }
    }
}
