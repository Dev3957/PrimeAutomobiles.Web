using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAutomobiles.Data.Models
{
    public class BillOfMaterial
    {
        [Key]
        public int BOMID { get; set; }

        [ForeignKey("ServiceRecord")]
        public int ServiceID { get; set; }

        [Required, MaxLength(100)]
        public string Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Cost { get; set; }

        // Navigation Property
        public ServiceRecord ServiceRecord { get; set; }
    }
}
