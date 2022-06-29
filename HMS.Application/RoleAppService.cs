using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Role;
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
    public class RoleAppService : IRoleAppService
    {
        IRepository<HMS.Core.Entities.Role> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public RoleAppService(IRepository<HMS.Core.Entities.Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(RoleInputDto roleInputDto)
        {
            var entity = _mapper.Map<Role>(roleInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                roleInputDto.Id = entityId;
                _responseOutputDto.Success<RoleInputDto>(roleInputDto);
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

            var roleOutputDto = _mapper.Map<List<RoleOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<RoleOutputDto>>(roleOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var roleOutputDto = _mapper.Map<RoleOutputDto>(entity);

            _responseOutputDto.Success<RoleOutputDto>(roleOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(RoleInputDto roleInputDto)
        {
            var entity = _mapper.Map<Role>(roleInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<RoleInputDto>(roleInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
