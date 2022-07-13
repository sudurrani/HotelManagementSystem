using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerCheckin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface ICustomerCheckInAppService
    {
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetByCustomerId(long customerId);

        //Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(CustomerCheckInInputDto customerCheckInInputDto);
        Task<ResponseOutputDto> GetNextVoucherNumber();



    }
}
