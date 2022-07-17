using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.FoodType;
using HMS.Application.Shared.Dtos.FoodTypeDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Interfaces
{
    public interface IFoodTypeDetailAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(long id);

        Task<ResponseOutputDto> Create(FoodTypeDetailInputDto foodTypeDetailInputDto);

        Task<ResponseOutputDto> Update(FoodTypeDetailInputDto foodTypeDetailInputDto);

        Task<ResponseOutputDto> Delete(long id);
    }
}
