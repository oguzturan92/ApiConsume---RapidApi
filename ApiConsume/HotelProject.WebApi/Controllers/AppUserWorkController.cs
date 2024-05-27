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
    public class AppUserWorkController : ControllerBase
    {

        // INJECT --------------------------------------------------------------------------
        private readonly IAppUserService _appUserService;
        public AppUserWorkController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        // LIST ----------------------------------------------------------------------
        [HttpGet]
        public IActionResult AppUserListAndWorkLocation()
        {
            var values = _appUserService.UserListAndWorkLocation();
            return Ok(values);
        }
    }
}