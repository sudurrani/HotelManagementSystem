using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Room;
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
    public class RoomAppService : IRoomAppService
    {
        IRepository<HMS.Core.Entities.Room> _repository;

        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();

        public RoomAppService(IRepository<HMS.Core.Entities.Room> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<ResponseOutputDto> Create(RoomInputDto roomInputDto)
        {
            var entity = _mapper.Map<Room>(roomInputDto);
            var entityId = await _repository.Create(entity);
            if(entityId>0)
            {
                roomInputDto.Id = entityId;
                _responseOutputDto.Success<RoomInputDto>(roomInputDto);
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

            var roomOutputDtos = _mapper.Map<List<RoomOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<RoomOutputDto>>(roomOutputDtos);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var roomOutputDto = _mapper.Map<RoomOutputDto>(entity);

            _responseOutputDto.Success<RoomOutputDto>(roomOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(RoomInputDto roomInputDto)
        {
            var entity = _mapper.Map<Room>(roomInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<RoomInputDto>(roomInputDto);
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
