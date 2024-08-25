using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; }

        [Required, MaxLength(15)]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        // Navigation Property for Vehicles
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
