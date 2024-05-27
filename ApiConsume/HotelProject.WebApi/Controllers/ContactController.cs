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
    public class ContactController : ControllerBase
    {
        // INJECT --------------------------------------------------------------------------
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.GetList();
            return Ok(values);
        }

        // CREATE ----------------------------------------------------------------------
        [HttpPost]
        public IActionResult ContactCreate(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            _contactService.Insert(contact);
            return Ok();
        }

        // GETBYID ----------------------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            var value = _contactService.GetById(id);
            return Ok(value);
        }

        // UPDATE ----------------------------------------------------------------------
        [HttpPut]
        public IActionResult ContactUpdate(Contact contact)
        {
            _contactService.Update(contact);
            return Ok();
        }

        // DELETE ----------------------------------------------------------------------
        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return Ok();
        }

        [HttpGet("GetContactCount")] // GetContactCount metoduna gidecek
        public IActionResult GetContactCount()
        {
            return Ok(_contactService.GetContactCount());
        }
    }
}