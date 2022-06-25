using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.PurposeOfVisit;
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
    public class PurposeOfVisitController : ControllerBase
    {
        private readonly IPurposeOfVisitAppService _purposeOfVisitAppService;
        public PurposeOfVisitController(IPurposeOfVisitAppService purposeOfVisitAppService)
        {
            _purposeOfVisitAppService = purposeOfVisitAppService;
        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _purposeOfVisitAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _purposeOfVisitAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(PurposeOfVisitInputDto purposeOfVisitInputDto)
        {
            var response = await _purposeOfVisitAppService.Create(purposeOfVisitInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(PurposeOfVisitInputDto purposeOfVisitInputDto)
        {
            var response = await _purposeOfVisitAppService.Update(purposeOfVisitInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _purposeOfVisitAppService.Delete(id);
            return Ok(response);
        }
    }
}
