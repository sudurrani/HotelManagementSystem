using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.FoodType;
using HMS.Application.Shared.Dtos.FoodTypeDetail;
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
    public class FoodTypeDetailAppService : IFoodTypeDetailAppService
    {
        IRepository<HMS.Core.Entities.FoodTypeDetail> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        IFoodTypeAppService _foodTypeAppService;
        public FoodTypeDetailAppService(IRepository<HMS.Core.Entities.FoodTypeDetail> repository,
            IFoodTypeAppService foodTypeAppService,IMapper mapper)
        {
            _repository = repository;
            _foodTypeAppService = foodTypeAppService;
            _mapper = mapper;

        }
        public async Task<ResponseOutputDto> Create(FoodTypeDetailInputDto foodTypeDetailInputDto)
        {
            var entity = _mapper.Map<FoodTypeDetail>(foodTypeDetailInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                foodTypeDetailInputDto.Id = entity.Id;
                _responseOutputDto.Success<FoodTypeDetailInputDto>(foodTypeDetailInputDto);
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
            var foodTypeOutpuDtos = (List<FoodTypeOutputDto>)_foodTypeAppService.GetAll().Result.resultJSON;
            var entities = await _repository.GetAll().ToListAsync();

            var foodTypeDetailOutputDto = _mapper.Map<List<FoodTypeDetailOutputDto>>(entities);

            foodTypeDetailOutputDto = foodTypeOutpuDtos.Join(
               foodTypeDetailOutputDto,
               foodTypeOutputDto => foodTypeOutputDto.Id,
               foodTypeDetailOutputDtos => foodTypeDetailOutputDtos.FoodTypeId,
               (foodTypeOutputDto, foodTypeDetailOutputDtos) => new FoodTypeDetailOutputDto
               {
                   Id= foodTypeDetailOutputDtos.Id,
                   Name=foodTypeDetailOutputDtos.Name,
                   Quantity= foodTypeDetailOutputDtos.Quantity,
                   Rate=foodTypeDetailOutputDtos.Rate,
                   FoodTypeId= foodTypeOutputDto.Id,
                   FoodType=foodTypeOutputDto.Name
               }).ToList();
            _responseOutputDto.Success<IEnumerable<FoodTypeDetailOutputDto>>(foodTypeDetailOutputDto);
            return _responseOutputDto;

        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var foodTypeDetailOutputDto = _mapper.Map<FoodTypeDetailOutputDto>(entity);

            _responseOutputDto.Success<FoodTypeDetailOutputDto>(foodTypeDetailOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(FoodTypeDetailInputDto foodTypeDetailInputDto)
        {
            var entity = _mapper.Map<FoodTypeDetail>(foodTypeDetailInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<FoodTypeDetailInputDto>(foodTypeDetailInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
