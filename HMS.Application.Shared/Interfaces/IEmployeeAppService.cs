using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IEmployeeAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(EmployeeInputDto employeeInputDto);

        Task<ResponseOutputDto> Update(EmployeeInputDto employeeInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
