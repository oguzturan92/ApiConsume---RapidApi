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
    public class BookingController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult BookingCreate(Booking booking)
        {
            _bookingService.Insert(booking);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult BookingUpdate(Booking booking)
        {
            _bookingService.Update(booking);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var value = _bookingService.GetById(id);
            _bookingService.Delete(value);
            return Ok();
        }

    }
}