using AutoMapper;
using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Dtos.User;
using HMS.Application.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application
{

    public class UserAppService : IUserAppService
    {
        IRepository<HMS.Core.Entities.User> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        private readonly IConfiguration iconfiguration;
        public UserAppService(IRepository<HMS.Core.Entities.User> repository, IMapper mapper, IConfiguration iconfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            this.iconfiguration = iconfiguration;

        }

    //    Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    //{
    //    { "user1","password1"},
    //    { "user2","password2"},
    //    { "user3","password3"},
    //};

        //private readonly IConfiguration iconfiguration;
        //public UserAppService(IConfiguration iconfiguration)
        //{
        //    this.iconfiguration = iconfiguration;
        //}
        public async Task<ResponseOutputDto> Authenticate(UserInputDto userInputDto)
        {
            var userEntity = _repository.GetAll().Where(filtter => filtter.Username == userInputDto.Username && filtter.Password == userInputDto.Password).FirstOrDefault() ;//.ToListAsync();
            
            //if (!UsersRecords.Any(x => x.Username == users.Username && x.Password == users.Password))
            //{
            //    _responseOutputDto.Error("Invalid credentials are provided");
            //    return _responseOutputDto;
            //}
            if(userEntity == null)
            {
                _responseOutputDto.Error("Invalid credentials are provided");
                return _responseOutputDto;
            }

            //var locationOutputDto = _mapper.Map<List<LocationOutputDto>>(entities);

            //_responseOutputDto.Success<IEnumerable<LocationOutputDto>>(locationOutputDto);
            //return _responseOutputDto;

            //if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            //{
            //    return null;
            //}

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Subject = new ClaimsIdentity(new Claim[]
              {
                    new Claim(ClaimTypes.Name, userEntity.Username)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userOutputDto = new UserOutputDto { Token = tokenHandler.WriteToken(token),Username = userEntity.Username };
            _responseOutputDto.Success<object>(userOutputDto);
            return _responseOutputDto;

        }
    }
}
