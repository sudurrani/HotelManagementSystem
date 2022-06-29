using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Organization;
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
    public class OrganizationAppService : IOrganizationAppService
    {
        IRepository<Organization> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public OrganizationAppService(IRepository<Organization> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(OrganizationInputDto organizationInputDto)
        {
            var entity = _mapper.Map<Organization>(organizationInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                organizationInputDto.Id = entityId;
                _responseOutputDto.Success<OrganizationInputDto>(organizationInputDto);
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

            var organizationOutputDto = _mapper.Map<List<OrganizationOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<OrganizationOutputDto>>(organizationOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var organizationOutputDto = _mapper.Map<OrganizationOutputDto>(entity);

            _responseOutputDto.Success<OrganizationOutputDto>(organizationOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(OrganizationInputDto organizationInputDto)
        {
            var entity = _mapper.Map<Organization>(organizationInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<OrganizationInputDto>(organizationInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
