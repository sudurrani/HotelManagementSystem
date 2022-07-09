using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.CustomerCheckin;
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
    public class CustomerCheckInController : ControllerBase
    {
        private readonly ICustomerCheckInAppService _customerCheckInAppService;
        public CustomerCheckInController(ICustomerCheckInAppService customerCheckInAppService)
        {
            _customerCheckInAppService = customerCheckInAppService;

        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerCheckInAppService.GetAll();
            return Ok(response);
        }

        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(CustomerCheckInInputDto customerCheckInInputDto)
        {
            var response = await _customerCheckInAppService.Create(customerCheckInInputDto);
            return Ok(response);
        }

        [Route("GetByCustomerId/{customerId}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetByCustomerId(long customerId)
        {
            var response = await _customerCheckInAppService.GetByCustomerId(customerId);
            return Ok(response);
        }
    }
}
