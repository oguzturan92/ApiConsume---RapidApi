using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.UserDto;
using HotelProject.WebUI.Models;
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
        private readonly RoleManager<AppRole> _roleManager;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpClientFactory httpClientFactory, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClientFactory = httpClientFactory;
            _roleManager = roleManager;
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
                        return RedirectToAction("Index", "Admin");
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
    
        [HttpGet]
        public async Task<IActionResult> UserRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = _roleManager.Roles.Select(i => i.Name);
            var userRoles = await _userManager.GetRolesAsync(user);
            var model = new UserRoleModel()
            {
                UserId = user.Id,
                Roles = roles,
                UserRoles = userRoles
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserRole(UserRoleModel model, string[] userNewRoles)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);
            userNewRoles = userNewRoles ?? new string[]{};
            await _userManager.AddToRolesAsync(user, userNewRoles.Except(userRoles).ToArray<string>());
            await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userNewRoles).ToArray<string>());
            return RedirectToAction("UserList", "User");
        }

        [HttpGet]
        public async Task<IActionResult> UserUpdate(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var model = new UserUpdateModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {   
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    }
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.City = model.City;
                    user.Email = model.Email;
                    var sonuc = await _userManager.UpdateAsync(user);
                    if (sonuc.Succeeded)
                    {
                        return RedirectToAction("UserList", "User");
                    } else
                    {
                        return View(model);
                    }
                }
            }
            return View(model);
        }
    
        public async Task<IActionResult> UserDelete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var userName1 = User.Identity.Name;
                if (userName1.ToLower() == user.UserName.ToLower())
                {
                    return RedirectToAction("UserList", "User");
                }

                var sonuc = await _userManager.DeleteAsync(user);
                if (sonuc.Succeeded)
                {
                    return RedirectToAction("UserList", "User");
                }
            }
            return RedirectToAction("UserList", "User");
        }
    }
}