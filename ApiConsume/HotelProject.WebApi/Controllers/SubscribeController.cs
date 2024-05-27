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
    public class SubscribeController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult SubscribeCreate(Subscribe subscribe)
        {
            _subscribeService.Insert(subscribe);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult SubscribeGet(int id)
        {
            var value = _subscribeService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult SubscribeUpdate(Subscribe subscribe)
        {
            _subscribeService.Update(subscribe);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult SubscribeDelete(int id)
        {
            var value = _subscribeService.GetById(id);
            _subscribeService.Delete(value);
            return Ok();
        }

    }
}