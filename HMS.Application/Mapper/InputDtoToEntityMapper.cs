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
    public class InputDtoToEntityMapper : Profile
    {
        public InputDtoToEntityMapper()
        {
            CreateMap<TestInputDto, Test>();
            CreateMap<RoomInputDto, Room>();
            CreateMap<LocationInputDto, Location>();
        }
    }
}
