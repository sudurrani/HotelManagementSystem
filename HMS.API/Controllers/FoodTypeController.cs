using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.FoodType;
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
    public class FoodTypeController : ControllerBase
    {
        private readonly IFoodTypeAppService _foodTypeAppService;
        public FoodTypeController(IFoodTypeAppService foodTypeAppService)
        {
            _foodTypeAppService = foodTypeAppService;
        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _foodTypeAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _foodTypeAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(FoodTypeInputDto foodTypeInputDto)
        {
            var response = await _foodTypeAppService.Create(foodTypeInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(FoodTypeInputDto foodTypeInputDto)
        {
            var response = await _foodTypeAppService.Update(foodTypeInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _foodTypeAppService.Delete(id);
            return Ok(response);
        }

    }
}
