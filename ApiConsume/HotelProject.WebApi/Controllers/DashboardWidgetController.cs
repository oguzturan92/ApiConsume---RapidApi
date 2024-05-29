using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;
        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet("StaffCount")] // Birden fazla metod tanımlanacağı içim, ilgili ismi buraya da yazıyoruz ki bu metoda gidebilsin.
        public IActionResult StaffCount()
        {
            var value = _staffService.GetStaffCount();
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.GetBookingCount();
            return Ok(value);
        }

        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var values = _appUserService.AppUserCount();
            return Ok(values);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var values = _roomService.RoomCount();
            return Ok(values);
        }

        [HttpGet("GetStaffLast4")]
        public IActionResult GetStaffLast4()
        {
            var values = _staffService.GetStaffLast4();
            return Ok(values);
        }

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values = _bookingService.Last6Booking();
            return Ok(values);
        }

    }
}