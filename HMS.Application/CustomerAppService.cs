using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Customer;
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
    public class CustomerAppService : ICustomerAppService
    {
        IRepository<HMS.Core.Entities.Customer> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public CustomerAppService(IRepository<HMS.Core.Entities.Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(CustomerInputDto customerInputDto)
        {
            var entity = _mapper.Map<Customer>(customerInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                customerInputDto.Id = entityId;
                _responseOutputDto.Success<CustomerInputDto>(customerInputDto);
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

            var customerOutputDto = _mapper.Map<List<CustomerOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<CustomerOutputDto>>(customerOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var customerOutputDto = _mapper.Map<CustomerOutputDto>(entity);

            _responseOutputDto.Success<CustomerOutputDto>(customerOutputDto);
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> GetByNIC(string nic)
        {
            var entity = await _repository.GetAll().Where(filter => filter.NIC == nic).FirstOrDefaultAsync();
            var customerOutputDto = _mapper.Map<CustomerOutputDto>(entity);

            _responseOutputDto.Success<CustomerOutputDto>(customerOutputDto);
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> Update(CustomerInputDto customerInputDto)
        {
            var entity = _mapper.Map<Customer>(customerInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<CustomerInputDto>(customerInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
