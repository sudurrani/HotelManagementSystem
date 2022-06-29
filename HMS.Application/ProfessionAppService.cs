using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Profession;
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
    public class ProfessionAppService : IProfessionAppService
    {
        private readonly IMapper _mapper;
        IRepository<HMS.Core.Entities.Profession> _repository;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();

        public ProfessionAppService(IRepository<HMS.Core.Entities.Profession> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(ProfessionInputDto professionInputDto)
        {
            var entity = _mapper.Map<Profession>(professionInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                professionInputDto.Id = entityId;
                _responseOutputDto.Success<ProfessionInputDto>(professionInputDto);
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

            var professionOutputDto = _mapper.Map<List<ProfessionOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<ProfessionOutputDto>>(professionOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var professionOutputDto = _mapper.Map<ProfessionOutputDto>(entity);

            _responseOutputDto.Success<ProfessionOutputDto>(professionOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(ProfessionInputDto professionInputDto)
        {
            var entity = _mapper.Map<Profession>(professionInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<ProfessionInputDto>(professionInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
