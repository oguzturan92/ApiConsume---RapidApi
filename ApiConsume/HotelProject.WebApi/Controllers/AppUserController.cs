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
    public class AppUserController : ControllerBase
    {

        // INJECT --------------------------------------------------------------------------
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult AppUserList()
        {
            var values = _appUserService.GetList();
            return Ok(values);
        }
    }
}