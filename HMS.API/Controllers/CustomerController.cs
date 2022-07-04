using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Customer;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;

        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _customerAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(CustomerInputDto customerInputDto)
        {
            var response = await _customerAppService.Create(customerInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(CustomerInputDto customerInputDto)
        {
            var response = await _customerAppService.Update(customerInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _customerAppService.Delete(id);
            return Ok(response);
        }
        [Route("GetByNIC/{nic}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetByNIC(string nic )
        {
            var response = await _customerAppService.GetByNIC(nic);
            return Ok(response);
        }
    }
}
