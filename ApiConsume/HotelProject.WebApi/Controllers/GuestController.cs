using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult GuestCreate(Guest guest)
        {
            _guestService.Insert(guest);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GuestGet(int id)
        {
            var value = _guestService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult GuestUpdate(Guest guest)
        {
            _guestService.Update(guest);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult GuestDelete(int id)
        {
            var value = _guestService.GetById(id);
            _guestService.Delete(value);
            return Ok();
        }
    }
}