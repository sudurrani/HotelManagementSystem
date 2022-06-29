using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.PurposeOfVisit;
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
    public class PurposeOfVisitAppService : IPurposeOfVisitAppService
    {
        IRepository<HMS.Core.Entities.PurposeOfVisit> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public PurposeOfVisitAppService(IRepository<HMS.Core.Entities.PurposeOfVisit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(PurposeOfVisitInputDto purposeOfVisitInputDto)
        {
            var entity = _mapper.Map<PurposeOfVisit>(purposeOfVisitInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                purposeOfVisitInputDto.Id = entityId;
                _responseOutputDto.Success<PurposeOfVisitInputDto>(purposeOfVisitInputDto);
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

            var purposeOfVisitOutputDto = _mapper.Map<List<PurposeOfVisitOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<PurposeOfVisitOutputDto>>(purposeOfVisitOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var purposeOfVisitOutputDto = _mapper.Map<PurposeOfVisitOutputDto>(entity);

            _responseOutputDto.Success<PurposeOfVisitOutputDto>(purposeOfVisitOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(PurposeOfVisitInputDto purposeOfVisitInputDto)
        {
            var entity = _mapper.Map<PurposeOfVisit>(purposeOfVisitInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<PurposeOfVisitInputDto>(purposeOfVisitInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
