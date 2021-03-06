using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.Room
{
    public class RoomInputDto : AuditedDto
    {

        public string Number { get; set; }
        public decimal Rent { get; set; }
        public bool IsAllotted { get; set; }
    }
}
