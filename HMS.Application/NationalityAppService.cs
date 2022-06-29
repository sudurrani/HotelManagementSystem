using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Nationality;
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
    public class NationalityAppService : INationalityAppService
    {
        IRepository<HMS.Core.Entities.Nationality> _repository;

        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();

        public NationalityAppService(IRepository<HMS.Core.Entities.Nationality> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(NationalityInputDto nationalityInputDto)
        {
            var entity = _mapper.Map<Nationality>(nationalityInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                nationalityInputDto.Id = entityId;
                _responseOutputDto.Success<NationalityInputDto>(nationalityInputDto);
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

            var nationalityOutputDto = _mapper.Map<List<NationalityOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<NationalityOutputDto>>(nationalityOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var nationalityOutputDto = _mapper.Map<NationalityOutputDto>(entity);

            _responseOutputDto.Success<NationalityOutputDto>(nationalityOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(NationalityInputDto nationalityInputDto)
        {
            var entity = _mapper.Map<Nationality>(nationalityInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<NationalityInputDto>(nationalityInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
