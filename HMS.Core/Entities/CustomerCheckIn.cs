﻿using HMS.Core.Common;
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
        public DateTime InDateTime { get; set; }


        public DateTime OutDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rent { get; set; }

        public int Days { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalRent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Paid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Remaining { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Remarks { get; set; }

        [ForeignKey("FromLocationId")]
        public virtual Location Location { get; set; }

        [ForeignKey("ToLocationId")]
        public virtual Location DepartureLocation { get; set; }

        [Required]
        public long RoomId { get; set; }
        public virtual Room Room { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
