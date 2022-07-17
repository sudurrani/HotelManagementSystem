using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.FoodType;
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
   public class FoodTypeAppService : IFoodTypeAppService
    {
        IRepository<HMS.Core.Entities.FoodType> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        IFoodTypeAppService _FoodTypeAppService;
        public FoodTypeAppService(IRepository<HMS.Core.Entities.FoodType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(FoodTypeInputDto foodTypeInputDto)
        {
            var entity = _mapper.Map<FoodType>(foodTypeInputDto);
            var entityId = await _repository.Create(entity);


            if (entityId > 0)
            {
                foodTypeInputDto.Id = entityId;
                _responseOutputDto.Success<FoodTypeInputDto>(foodTypeInputDto);
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

            var foodTypeOutputDtos = _mapper.Map<List<FoodTypeOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<FoodTypeOutputDto>>(foodTypeOutputDtos);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var foodTypeOutputDto = _mapper.Map<FoodTypeOutputDto>(entity);

            _responseOutputDto.Success<FoodTypeOutputDto>(foodTypeOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(FoodTypeInputDto foodTypeInputDto)
        {
            var entity = _mapper.Map<FoodType>(foodTypeInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<FoodTypeInputDto>(foodTypeInputDto);
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
