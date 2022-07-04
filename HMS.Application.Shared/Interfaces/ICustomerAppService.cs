using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface ICustomerAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> GetByNIC(string nic);

        Task<ResponseOutputDto> Create(CustomerInputDto customerInputDto);

        Task<ResponseOutputDto> Update(CustomerInputDto customerInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
