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
    public class MessageCategoryController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IMessageCategoryService _messageCategoryService;
        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult MessageCategoryCreate(MessageCategory messageCategory)
        {
            _messageCategoryService.Insert(messageCategory);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult MessageCategoryGet(int id)
        {
            var value = _messageCategoryService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult MessageCategoryUpdate(MessageCategory messageCategory)
        {
            _messageCategoryService.Update(messageCategory);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult MessageCategoryDelete(int id)
        {
            var value = _messageCategoryService.GetById(id);
            _messageCategoryService.Delete(value);
            return Ok();
        }

    }
}