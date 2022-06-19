using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface ITestAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(TestInputDto testInputDto);

        Task<ResponseOutputDto> Update(TestInputDto testInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
