using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class FoodType:AuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
