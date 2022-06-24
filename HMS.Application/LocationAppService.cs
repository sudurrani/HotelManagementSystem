using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Location;
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
    public class LocationAppService : ILocationAppService
    {
        IRepository<HMS.Core.Entities.Location> _repository;

        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public LocationAppService(IRepository<HMS.Core.Entities.Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<ResponseOutputDto> Create(LocationInputDto locationInputDto)
        {
            var entity = _mapper.Map<Location>(locationInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                locationInputDto.Id = entityId;
                _responseOutputDto.Success<LocationInputDto>(locationInputDto);
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

            var locationOutputDto = _mapper.Map<List<LocationOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<LocationOutputDto>>(locationOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var locationOutputDto = _mapper.Map<LocationOutputDto>(entity);

            _responseOutputDto.Success<LocationOutputDto>(locationOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(LocationInputDto locationInputDto)
        {
            var entity = _mapper.Map<Location>(locationInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<LocationInputDto>(locationInputDto);
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
    }
}
