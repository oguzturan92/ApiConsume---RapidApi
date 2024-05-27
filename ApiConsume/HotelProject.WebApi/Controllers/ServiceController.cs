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
    public class ServiceController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult ServiceCreate(Service service)
        {
            _serviceService.Insert(service);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult ServiceGet(int id)
        {
            var value = _serviceService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult ServiceUpdate(Service service)
        {
            _serviceService.Update(service);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult ServiceDelete(int id)
        {
            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            return Ok();
        }

    }
}