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
    public class FoodTypeDetail : AuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }
        public long? FoodTypeId { get; set; }

        //  [ForeignKey("FoodTypeId")]
      //public virtual FoodType Food{get; set;}
    }
}
