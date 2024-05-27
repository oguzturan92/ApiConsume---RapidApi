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
    public class TestimonialController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult TestimonialCreate(Testimonial testimonial)
        {
            _testimonialService.Insert(testimonial);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            _testimonialService.Update(testimonial);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.GetById(id);
            _testimonialService.Delete(value);
            return Ok();
        }

    }
}