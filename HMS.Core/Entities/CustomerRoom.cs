using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class CustomerRoom : AuditedEntity
    {
        [Required]
        public DateTime ArrivalDateTime { get; set; }
        [ForeignKey("CommingFromId")]
        public virtual Location Location { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }
        [ForeignKey("NextDestinationId")]
        public virtual Location DepartureLocation { get; set; }


        [Required]

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RoomRentFor24Hour { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AdvancePayment { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Remarks { get; set; }
    }

}
