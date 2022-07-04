using AutoMapper;
using HMS.Application.Shared.Dtos.Customer;
using HMS.Application.Shared.Dtos.Employee;
using HMS.Application.Shared.Dtos.Location;
using HMS.Application.Shared.Dtos.Nationality;
using HMS.Application.Shared.Dtos.Profession;
using HMS.Application.Shared.Dtos.Room;
using HMS.Application.Shared.Dtos.Test;
using HMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Mapper
{
    public class EntityToOutputDtoMapper : Profile
    {
        public EntityToOutputDtoMapper()
        {
            CreateMap<Test, TestOutputDto>();
            CreateMap<Room, RoomOutputDto>();
            CreateMap<Location, LocationOutputDto>();
            CreateMap<Profession, ProfessionOutputDto>();
            CreateMap<Nationality, NationalityOutputDto>();
            CreateMap<Employee, EmployeeOutputDto>();
            CreateMap<Customer, CustomerOutputDto>();
        }
    }
}
