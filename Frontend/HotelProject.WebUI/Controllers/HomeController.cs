using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.WebUI.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AdminIndex()
    {
        return View();
    }
}
