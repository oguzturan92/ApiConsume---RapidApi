using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateModel model)
        {
            var appRole = new AppRole()
            {
                Name = model.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList", "Role");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RoleUpdate(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(i => i.Id == id);
            var model = new RoleUpdateModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateModel model)
        {
            var role = _roleManager.Roles.FirstOrDefault(i => i.Id == model.Id);
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList", "Role");
            }
            return View(model);
        }

        public async Task<IActionResult> RoleDelete(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(i => i.Id == id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("RoleList", "Role");
        }


    }
}