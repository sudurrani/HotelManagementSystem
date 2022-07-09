using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.CustomerCheckin;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
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
    public class CustomerCheckInAppService : ICustomerCheckInAppService
    {
        IRepository<HMS.Core.Entities.CustomerCheckIn> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        ICustomerCheckInRoomAppService _customerCheckInRoomAppService;
        public CustomerCheckInAppService(IRepository<HMS.Core.Entities.CustomerCheckIn> repository
            ,ICustomerCheckInRoomAppService customerCheckInRoomAppService
            ,IMapper mapper)
        {
            _repository = repository;
            _customerCheckInRoomAppService = customerCheckInRoomAppService;
            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(CustomerCheckInInputDto customerCheckInInputDto)
        {
            var entity = _mapper.Map<CustomerCheckIn>(customerCheckInInputDto);
            

                var entityId = await _repository.Create(entity);
                if (entityId > 0)
                {
                    var customerCheckInRoomInputDtos = new List<CustomerCheckInRoomInputDto>();
                    foreach(var room in customerCheckInInputDto.Rooms)
                    {
                        customerCheckInRoomInputDtos.Add(new CustomerCheckInRoomInputDto()
                        {
                            CustomerCheckInId = entity.Id,
                            RoomId = room.Id
                        });
                    }
                    if(customerCheckInRoomInputDtos.Count > 0)
                    {
                      var responseOutputDto =  await _customerCheckInRoomAppService.CreateRange(customerCheckInRoomInputDtos);
                        if(responseOutputDto.IsSuccess)
                        {
                            customerCheckInInputDto.Id = entityId;
                            _responseOutputDto.Success<CustomerCheckInInputDto>(customerCheckInInputDto);
                        }
                        else
                        {
                            _responseOutputDto.Error();
                        }
                    }
                    
                }
                else
                {
                    _responseOutputDto.Error();
                }
            
            
            return _responseOutputDto;

        }
        public async Task<ResponseOutputDto> GetByCustomerId(long customerId)
        {
            var entities = await _repository.GetAll().Where(filter => filter.CustomerId == customerId).ToListAsync();

            var customerCheckInOutputDto = _mapper.Map<List<CustomerCheckInOutputDto>>(entities);
            var customerCheckInOutputDtos = new List<CustomerCheckInOutputDto>();

            string rooms = null;
            foreach (var customerCheckIn in customerCheckInOutputDto)
            {                
                var customerCheckInRooms =await _customerCheckInRoomAppService.GetByCustomerCheckInId(customerCheckIn.Id);
                foreach(var room in customerCheckInRooms.resultJSON)
                {
                    rooms = rooms == null ? room.RoomNumber.ToString() : rooms + ", " + room.RoomNumber.ToString();
                }
                customerCheckIn.Rooms = rooms;
                customerCheckInOutputDtos.Add(customerCheckIn);
                rooms = null;
            }
            _responseOutputDto.Success<IEnumerable<CustomerCheckInOutputDto>>(customerCheckInOutputDtos);
            return _responseOutputDto;

        }
    }
}
