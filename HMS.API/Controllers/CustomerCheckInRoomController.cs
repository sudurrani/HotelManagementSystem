using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerCheckInRoom;
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
    public class CustomerCheckInRoomController : ControllerBase
    {
        private readonly ICustomerCheckInRoomAppService _customerCheckInRoomAppService;
        public CustomerCheckInRoomController(ICustomerCheckInRoomAppService customerCheckInRoomAppService)
        {
            _customerCheckInRoomAppService = customerCheckInRoomAppService;
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> CreateRange(List<CustomerCheckInRoomInputDto> customerCheckInRoomInputDtos)
        {
            var response = await _customerCheckInRoomAppService.CreateRange(customerCheckInRoomInputDtos);
            return Ok(response);
        }
    }
}
