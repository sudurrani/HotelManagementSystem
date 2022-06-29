using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.Organization
{
    public class OrganizationInputDto:AuditedDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Password { get; set; }
        public string ContactPerson1Name { get; set; }
        public string ContactPerson1Number { get; set; }
        public string ContactPerson2Name { get; set; }
        public string ContactPerson2Number { get; set; }
        public string ContactPerson3Name { get; set; }
        public string ContactPerson3Number { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string RegistrationYear { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
