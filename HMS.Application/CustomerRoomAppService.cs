using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.CustomerRoom;
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
    public class CustomerRoomAppService : ICustomerRoomAppService
    {
        IRepository<HMS.Core.Entities.CustomerRoom> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public CustomerRoomAppService(IRepository<HMS.Core.Entities.CustomerRoom> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(CustomerRoomInputDto customerRoomInputDto)
        {
            var entity = _mapper.Map<CustomerRoom>(customerRoomInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                customerRoomInputDto.Id = entityId;
                _responseOutputDto.Success<CustomerRoomInputDto>(customerRoomInputDto);
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

            var customerRoomOutputDto = _mapper.Map<List<CustomerRoomOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<CustomerRoomOutputDto>>(customerRoomOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var customerRoomOutputDto = _mapper.Map<CustomerRoomOutputDto>(entity);

            _responseOutputDto.Success<CustomerRoomOutputDto>(customerRoomOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(CustomerRoomInputDto customerRoomInputDto)
        {
            var entity = _mapper.Map<CustomerRoom>(customerRoomInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<CustomerRoomInputDto>(customerRoomInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
