using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> SubscribeList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/Subscribe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SubscribeListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> SubscribeDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Subscribe/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscribeList", "Subscribe");
            }
            return RedirectToAction("SubscribeList", "Subscribe");
        }

        // CLIENT --------------------------------------------------------------------------
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SubscribeCreate(SubscribeCreateDto subscribeCreateDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(subscribeCreateDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/Subscribe", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}