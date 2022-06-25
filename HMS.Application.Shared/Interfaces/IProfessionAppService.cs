using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Profession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IProfessionAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(ProfessionInputDto professionInputDto);

        Task<ResponseOutputDto> Update(ProfessionInputDto professionInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
