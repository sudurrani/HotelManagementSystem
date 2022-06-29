using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Nationality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface INationalityAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(NationalityInputDto nationalityInputDto);

        Task<ResponseOutputDto> Update(NationalityInputDto nationalityInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
