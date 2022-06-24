using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class Employee : AuditedEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        //Further properties will be adding later for now just creating to add EmployeeId as F.K in User entity

        public ICollection<User> Users { get; set; }
    }
}
