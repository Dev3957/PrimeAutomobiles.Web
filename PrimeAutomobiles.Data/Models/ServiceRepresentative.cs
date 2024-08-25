using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Models
{
    public class ServiceRepresentative
    {
        [Key]
        public int ServiceAdvisorID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(15)]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        // Navigation Property for Service Records
        public ICollection<ServiceRecord> ServiceRecords { get; set; }
    }
}
