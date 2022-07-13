using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.CustomerCheckInRoom
{
    public class CustomerCheckInRoomInputDto : AuditedDto
    {
        public long CustomerCheckInId { get; set; }
        public long RoomId { get; set; }        
    }
}
