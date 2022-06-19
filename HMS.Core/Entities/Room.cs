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
   public class Room:AuditedEntity
    {
 
            [Column(TypeName="nvarchar(50)")]
        public string Number { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Rent { get; set; }
    }
}
