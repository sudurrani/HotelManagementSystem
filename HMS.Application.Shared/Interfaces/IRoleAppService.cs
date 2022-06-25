using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IRoleAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(RoleInputDto roleInputDto);

        Task<ResponseOutputDto> Update(RoleInputDto roleInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
