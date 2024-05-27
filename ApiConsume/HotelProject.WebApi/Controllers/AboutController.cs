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
    public class AboutController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult AboutCreate(About about)
        {
            _aboutService.Insert(about);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult AboutUpdate(About about)
        {
            _aboutService.Update(about);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult AboutDelete(int id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            return Ok();
        }

    }
}