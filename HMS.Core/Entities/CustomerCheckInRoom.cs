using HMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class CustomerCheckInRoom : AuditedEntity
    {
        public long CustomerCheckInId { get; set; }
        public virtual CustomerCheckIn CustomerCheckIn { get; set; }
        public long RoomId { get; set; }
        public virtual Room Room { get; set; }
       
    }
}
