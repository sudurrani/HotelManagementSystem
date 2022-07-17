using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.FoodTypeDetail;
using HMS.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeDetailController : ControllerBase
    {
        private readonly IFoodTypeDetailAppService _foodTypeDetailAppService;
        public FoodTypeDetailController(IFoodTypeDetailAppService foodTypeDetailAppService)
        {
            _foodTypeDetailAppService = foodTypeDetailAppService;


        }

        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _foodTypeDetailAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _foodTypeDetailAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(FoodTypeDetailInputDto foodTypeDetailInputDto)
        {
            var response = await _foodTypeDetailAppService.Create(foodTypeDetailInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(FoodTypeDetailInputDto foodTypeDetailInputDto)
        {
            var response = await _foodTypeDetailAppService.Update(foodTypeDetailInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _foodTypeDetailAppService.Delete(id);
            return Ok(response);
        }

    }
}
