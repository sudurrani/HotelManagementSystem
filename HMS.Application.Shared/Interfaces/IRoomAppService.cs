using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IRoomAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(RoomInputDto roomInputDto);

        Task<ResponseOutputDto> Update(RoomInputDto roomInputDto);

        Task<ResponseOutputDto> Delete(long id);

    }
}
