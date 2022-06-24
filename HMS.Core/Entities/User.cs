using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class User :AuditedEntity
    {
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

        //Foreign key for Employee
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //Foreign key for Employee
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
