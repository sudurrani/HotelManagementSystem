using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
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
    public class CustomerCheckInRoomAppService : ICustomerCheckInRoomAppService
    {
        IRepository<CustomerCheckInRoom> _repository;        
        private readonly IMapper _mapper;
        IRoomAppService _roomAppService;

        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public CustomerCheckInRoomAppService(IRepository<CustomerCheckInRoom> repository,            
            IRoomAppService roomAppService,
            IMapper mapper
            )
        {
            _repository = repository;            
            _roomAppService = roomAppService;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> CreateRange(List<CustomerCheckInRoomInputDto> customerCheckInRoomInputDtos)
        {
            var entity = _mapper.Map<List<CustomerCheckInRoom>>(customerCheckInRoomInputDtos);
            var entityId = await _repository.AddRange(entity);
            if (entityId > 0)
            {
                //customerInputDto.Id = entityId;
                _responseOutputDto.Success<List<CustomerCheckInRoomInputDto>>(customerCheckInRoomInputDtos);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> GetByCustomerCheckInId(long customerCheckInId)
        {
            var entities = await _repository.GetAll().Where(filter => filter.CustomerCheckInId == customerCheckInId).ToListAsync();
            var customerCheckInRoomOutputDtos = _mapper.Map<List<CustomerCheckInRoomOutputDto>>(entities);

            var roomOutputDtos =  (List<RoomOutputDto>) _roomAppService.GetAll().Result.resultJSON;

            customerCheckInRoomOutputDtos =  customerCheckInRoomOutputDtos.Join(
               roomOutputDtos,
               customerCheckInRoomOutputDto => customerCheckInRoomOutputDto.RoomId,
               roomOutputDto => roomOutputDto.Id,
               (customerCheckInRoomOutputDto, roomOutputDto) => new CustomerCheckInRoomOutputDto
               {
                   CustomerCheckInId = customerCheckInRoomOutputDto.Id,
                   RoomId = customerCheckInRoomOutputDto.RoomId,
                   RoomNumber = roomOutputDto.Number
               }).ToList();           
               //.Where(EmployeeAndAddress => EmployeeAndAddress.EmployeeName.id == EmployeeAndAddress.EmployeAddress.Empid).ToList();


            _responseOutputDto.Success<IEnumerable<CustomerCheckInRoomOutputDto>>(customerCheckInRoomOutputDtos);
            return _responseOutputDto;
        }
    }
}
