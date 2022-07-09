using HMS.Application.Shared.Common.Dtos;
using HMS.Application.Shared.Dtos.Room;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomAppService _roomAppService;
        public RoomController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;

        }
        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roomAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _roomAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(RoomInputDto roomInputDto)
        {
            var response = await _roomAppService.Create(roomInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(RoomInputDto roomInputDto)
        {
            var response = await _roomAppService.Update(roomInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _roomAppService.Delete(id);
            return Ok(response);
        }
        [Route("GetAvailable")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAvailable()
        {
            var response = await _roomAppService.GetAvailable();
            return Ok(response);
        }
    }
}
