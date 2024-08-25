using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Models
{
    public class ServiceRecord
    {
        [Key]
        public int ServiceID { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [ForeignKey("ServiceRepresentative")]
        public int ServiceAdvisorID { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; }

        // Navigation Properties
        public Vehicle Vehicle { get; set; }
        public ServiceRepresentative ServiceRepresentative { get; set; }

        // Navigation Property for Bill of Materials
        public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
    }
}
