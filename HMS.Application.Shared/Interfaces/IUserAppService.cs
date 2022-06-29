    using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IUserAppService
    {
        Task<ResponseOutputDto> Authenticate(UserInputDto userInputDto);
    }
}
