using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
   public class Role : AuditedEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
