using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
using HMS.Application.Shared.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.CustomerCheckin
{
    public class CustomerCheckInInputDto : AuditedDto
    {
        public DateTime CheckIn { get; set; }


        public DateTime? CheckOut { get; set; }

        public int Days { get; set; }

        public decimal TotalRent { get; set; }

        public decimal Paid { get; set; }

        public decimal Remaining { get; set; }

        public string CompanyName { get; set; }

        public string Remarks { get; set; }

        public long? FromLocationId { get; set; }

        public long? ToLocationId { get; set; }


        public long CustomerId { get; set; }

        public List<RoomInputDto> Rooms { get; set; }
    }
}
