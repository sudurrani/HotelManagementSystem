using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.Customer
{
    public class CustomerInputDto:AuditedDto
    {

        public string Title { get; set; }


        public string Name { get; set; }

        public string FatherName { get; set; }


        public int NationalityId { get; set; }

        public int ProfessionId { get; set; }

        public string NIC { get; set; }

        public string PassportNo { get; set; }

        public string ContactNumber { get; set; }
        public DateTime DOB { get; set; }


        public string HomeAddress { get; set; }
    }
}
