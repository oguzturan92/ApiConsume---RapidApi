using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult StaffCreate(Staff staff)
        {
            _staffService.Insert(staff);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult StaffGet(int id)
        {
            var value = _staffService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult StaffUpdate(Staff staff)
        {
            _staffService.Update(staff);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult StaffDelete(int id)
        {
            var value = _staffService.GetById(id);
            _staffService.Delete(value);
            return Ok();
        }

    }
}