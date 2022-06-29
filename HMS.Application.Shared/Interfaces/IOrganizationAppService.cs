using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IOrganizationAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(OrganizationInputDto organizationInputDto);

        Task<ResponseOutputDto> Update(OrganizationInputDto organizationInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
