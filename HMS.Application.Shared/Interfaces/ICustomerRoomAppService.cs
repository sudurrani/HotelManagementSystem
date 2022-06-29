using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
   public interface ICustomerRoomAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(CustomerRoomInputDto customerRoomInputDto);

        Task<ResponseOutputDto> Update(CustomerRoomInputDto customerRoomInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
