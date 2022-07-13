using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.Customer;
using HMS.Application.Shared.Dtos.CustomerCheckin;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
using HMS.Application.Shared.Dtos.Room;
using HMS.Application.Shared.Interfaces;
using HMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        ICustomerAppService _customerAppService;
        IRoomAppService _roomAppService;
        public CustomerCheckInAppService(IRepository<HMS.Core.Entities.CustomerCheckIn> repository
            , ICustomerCheckInRoomAppService customerCheckInRoomAppService
            , ICustomerAppService customerAppService
            , IRoomAppService roomAppService
            , IMapper mapper)
        {
            _repository = repository;
            _customerCheckInRoomAppService = customerCheckInRoomAppService;
            _customerAppService = customerAppService;
            _roomAppService = roomAppService;

            _mapper = mapper;
        }
        public async Task<ResponseOutputDto> Create(CustomerCheckInInputDto customerCheckInInputDto)
        {
            var entity = _mapper.Map<CustomerCheckIn>(customerCheckInInputDto);


            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                var customerCheckInRoomInputDtos = new List<CustomerCheckInRoomInputDto>();

                int rowIndex = 0;
                foreach (var room in customerCheckInInputDto.Rooms)
                {
                    customerCheckInRoomInputDtos.Add(new CustomerCheckInRoomInputDto()
                    {
                        CustomerCheckInId = entity.Id,
                        RoomId = room.Id
                    });
                    customerCheckInInputDto.Rooms[rowIndex].IsAllotted = true;
                    rowIndex += 1;

                }
                if (customerCheckInRoomInputDtos.Count > 0)
                {
                    var responseOutputDto = await _customerCheckInRoomAppService.CreateRange(customerCheckInRoomInputDtos);
                    if (responseOutputDto.IsSuccess)
                    {
                        customerCheckInInputDto.Id = entityId;

                        responseOutputDto = await _roomAppService.UpdateRange(customerCheckInInputDto.Rooms);
                        if (responseOutputDto.IsSuccess)
                        {
                            _responseOutputDto.Success<CustomerCheckInInputDto>(customerCheckInInputDto);
                        }
                        else
                        {
                            _responseOutputDto.Error();
                        }
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
        public async Task<ResponseOutputDto> GetAll()
        {
            var customerOutputDtos = (List<CustomerOutputDto>)_customerAppService.GetAll().Result.resultJSON;
            var customerCheckInEntities = await _repository.GetAll().ToListAsync();
            var customerCheckInOutputDtos = _mapper.Map<List<CustomerCheckInOutputDto>>(customerCheckInEntities);

            customerCheckInOutputDtos = customerOutputDtos.Join(
               customerCheckInOutputDtos,
               customerOutputDto => customerOutputDto.Id,
               customerCheckInOutputDto => customerCheckInOutputDto.CustomerId,
               (customerOutputDto, customerCheckInOutputDto) => new CustomerCheckInOutputDto
               {
                   Id = customerCheckInOutputDto.Id,
                   VoucherNumber = customerCheckInOutputDto.VoucherNumber,
                   CheckIn = customerCheckInOutputDto.CheckIn,
                   CheckOut = customerCheckInOutputDto.CheckOut,
                   Days = customerCheckInOutputDto.Days,
                   TotalRent = customerCheckInOutputDto.TotalRent,
                   Paid = customerCheckInOutputDto.Paid,
                   Remaining = customerCheckInOutputDto.Remaining,
                   CompanyName = customerCheckInOutputDto.CompanyName,
                   Remarks = customerCheckInOutputDto.Remarks,
                   Customer = customerOutputDto.Name,
                   CustomerId = customerOutputDto.Id

               }).Where(filter => filter.CheckOut == null).OrderByDescending(order => order.CreatedDateTime)
                .ToList();
            string rooms = null;
            for (int index = 0; index < customerCheckInOutputDtos.Count; index++)
            {
                var customerCheckInRooms = await _customerCheckInRoomAppService.GetByCustomerCheckInId(customerCheckInOutputDtos[index].Id);
                foreach (var room in customerCheckInRooms.resultJSON)
                {
                    rooms = rooms == null ? room.RoomNumber.ToString() : rooms + ", " + room.RoomNumber.ToString();
                }
                customerCheckInOutputDtos[index].Rooms = rooms;

                rooms = null;
            }


            _responseOutputDto.Success<IEnumerable<CustomerCheckInOutputDto>>(customerCheckInOutputDtos);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetByCustomerId(long customerId)
        {
            var entities = await _repository.GetAll().Where(filter => filter.CustomerId == (customerId == 0 ? filter.CustomerId : customerId)).OrderByDescending(order => order.CreatedDateTime).ToListAsync();

            var customerCheckInOutputDto = _mapper.Map<List<CustomerCheckInOutputDto>>(entities);
            var customerCheckInOutputDtos = new List<CustomerCheckInOutputDto>();

            string rooms = null;
            foreach (var customerCheckIn in customerCheckInOutputDto)
            {
                var customerCheckInRooms = await _customerCheckInRoomAppService.GetByCustomerCheckInId(customerCheckIn.Id);
                foreach (var room in customerCheckInRooms.resultJSON)
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
        public async Task<ResponseOutputDto> GetNextVoucherNumber()
        {            
            var customerCheckInEntities = await _repository.GetAll().ToListAsync();
            int count = customerCheckInEntities.Count();

            dynamic output = new ExpandoObject();
            output.voucherNumber = "VN-"+count.ToString().PadLeft(5, '0');


            _responseOutputDto.Success<dynamic>(output);
            return _responseOutputDto;
        }
    }
}
