using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.FoodType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IFoodTypeAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(FoodTypeInputDto foodTypeInputDto);

        Task<ResponseOutputDto> Update(FoodTypeInputDto foodTypeInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
