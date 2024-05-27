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
    public class WorkLocationController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IWorkLocationService _workLocationService;
        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult WorkLocationCreate(WorkLocation workLocation)
        {
            _workLocationService.Insert(workLocation);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult WorkLocationGet(int id)
        {
            var value = _workLocationService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult WorkLocationUpdate(WorkLocation workLocation)
        {
            _workLocationService.Update(workLocation);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult WorkLocationDelete(int id)
        {
            var value = _workLocationService.GetById(id);
            _workLocationService.Delete(value);
            return Ok();
        }

    }
}