using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface ICustomerCheckInRoomAppService
    {
        Task<ResponseOutputDto> CreateRange(List<CustomerCheckInRoomInputDto> customerCheckInRoomInputDtos);
        Task<ResponseOutputDto> GetByCustomerCheckInId(long customerCheckInId);        

    }
}
