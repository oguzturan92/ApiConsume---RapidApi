using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult RoomCreate(RoomCreateDto roomCreateDto)
        {
            if (ModelState.IsValid)
            {
                var value = _mapper.Map<Room>(roomCreateDto);
                _roomService.Insert(value);
                return Ok();
            }
            return BadRequest();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult RoomGet(int id)
        {
            var value = _roomService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult RoomUpdate(RoomUpdateDto roomUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var value = _mapper.Map<Room>(roomUpdateDto);
                _roomService.Update(value);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult RoomDelete(int id)
        {
            var value = _roomService.GetById(id);
            _roomService.Delete(value);
            return Ok();
        }

    }
}