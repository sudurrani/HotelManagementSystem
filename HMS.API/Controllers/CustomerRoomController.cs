using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerRoom;
using HMS.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class CustomerRoomController : ControllerBase
    {
        private readonly ICustomerRoomAppService _customerRoomAppService;
        public CustomerRoomController(ICustomerRoomAppService customerRoomAppService)
        {
            _customerRoomAppService = customerRoomAppService;

        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerRoomAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _customerRoomAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(CustomerRoomInputDto customerRoomInputDto)
        {
            var response = await _customerRoomAppService.Create(customerRoomInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(CustomerRoomInputDto customerRoomInputDto)
        {
            var response = await _customerRoomAppService.Update(customerRoomInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _customerRoomAppService.Delete(id);
            return Ok(response);
        }
    }
}
