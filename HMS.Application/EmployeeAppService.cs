using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Employee;
using HMS.Application.Shared.Interfaces;
using HMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application
{
    public class EmployeeAppService : IEmployeeAppService
    {
        IRepository<HMS.Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public EmployeeAppService(IRepository<HMS.Core.Entities.Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(EmployeeInputDto employeeInputDto)
        {
            var entity = _mapper.Map<Employee>(employeeInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                employeeInputDto.Id = entityId;
                _responseOutputDto.Success<EmployeeInputDto>(employeeInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var entity = await _repository.GetById(id);
            entity.IsDeleted = true;
            var result = await _repository.Delete(entity);
            if (result > 0)
            {
                _responseOutputDto.Success<object>(entity);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var entities = await _repository.GetAll().ToListAsync();

            var employeeOutputDto = _mapper.Map<List<EmployeeOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<EmployeeOutputDto>>(employeeOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var employeeOutputDto = _mapper.Map<EmployeeOutputDto>(entity);

            _responseOutputDto.Success<EmployeeOutputDto>(employeeOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(EmployeeInputDto employeeInputDto)
        {
            var entity = _mapper.Map<Employee>(employeeInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<EmployeeInputDto>(employeeInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
