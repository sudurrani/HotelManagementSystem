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
    public class Customer : AuditedEntity
    {
        [Column(TypeName = "nvarchar(20)")]
        public string NIC { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PassportNo { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FatherName { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }
        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }
      
        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string ContactNo { get; set; }
        public DateTime DOB { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string HomeAddress { get; set; }

        public ICollection<CustomerCheckIn> CustomerCheckIn { get; set; }
    }

}
