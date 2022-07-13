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
    public class CustomerCheckIn : AuditedEntity
    {
        [Required]
        public string VoucherNumber { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }


        public DateTime? CheckOut { get; set; }
        

        public int Days { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalRent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Paid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Remaining { get; set; }

        [MaxLength(200)]
        public string CompanyName { get; set; }

        [MaxLength(500)]
        public string Remarks { get; set; }
        
        public long? FromLocationId { get; set; }
        //public virtual Location Location { get; set; }

        public long? ToLocationId { get; set; }
        //public virtual Location DepartureLocation { get; set; }        

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
