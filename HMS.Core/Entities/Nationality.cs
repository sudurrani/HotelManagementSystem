using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class Nationality:AuditedEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
