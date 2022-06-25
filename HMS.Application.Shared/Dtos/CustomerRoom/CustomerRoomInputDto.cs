using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.CustomerRoom
{
    public class CustomerRoomInputDto:AuditedDto
    {
        public DateTime ArrivalDateTime { get; set; }
        public int LocationId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int DepartureLocationId { get; set; }
        public int RoomId { get; set; }
        public decimal RoomRentFor24Hour { get; set; }
        public decimal AdvancePayment { get; set; }
        public string CompanyName { get; set; }
        public string Remarks { get; set; }
    }
}
