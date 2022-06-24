using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Test;
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
    public class TestAppService : ITestAppService
    {
        IRepository<HMS.Core.Entities.Test> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public TestAppService(IRepository<HMS.Core.Entities.Test> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(TestInputDto testInputDto)
        {          
            var entity = _mapper.Map<Test>(testInputDto);
            var entityId = await _repository.Create(entity);


            if (entityId > 0)
            {
                testInputDto.Id = entityId;
                _responseOutputDto.Success<TestInputDto>(testInputDto);
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

                var testOutputDtos = _mapper.Map<List<TestOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<TestOutputDto>>(testOutputDtos);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            var testOutputDto = _mapper.Map<TestOutputDto>(entity);

            _responseOutputDto.Success<TestOutputDto>(testOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(TestInputDto testInputDto)
        {
            var entity = _mapper.Map<Test>(testInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<TestInputDto>(testInputDto);
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
