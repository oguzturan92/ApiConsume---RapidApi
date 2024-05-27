using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AppUserListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> UserListAndWorkLocation()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/AppUserWork");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AppUserListWorkDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.Surname,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    WorkLocationId = 1 // WorkLocation tablosunda 1 numaralı id verisi olmalı
                };

                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                // Kullanıcı ekleme başarısız hata mesajı
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(loginDto.UserName);
                if (appUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(appUser, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }
            }
            return View();
        }

        public IActionResult UserLogout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("UserLogin","User");
        }
    }
}