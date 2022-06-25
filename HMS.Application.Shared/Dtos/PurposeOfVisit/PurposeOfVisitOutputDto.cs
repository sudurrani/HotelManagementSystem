using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.PurposeOfVisit
{
    public class PurposeOfVisitOutputDto:AuditedDto
    {     
        public string Purpose { get; set; }
    }
}
