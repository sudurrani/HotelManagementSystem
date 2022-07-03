using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.Employee
{
   public class EmployeeOutputDto:AuditedDto
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string FatherName { get; set; }
        public string PermanentAddess { get; set; }
        public string ResidentialAddress { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }

    }
}
