using AutoMapper;
using HMS.Application.Shared.Dtos.Location;
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
        }
    }
}
