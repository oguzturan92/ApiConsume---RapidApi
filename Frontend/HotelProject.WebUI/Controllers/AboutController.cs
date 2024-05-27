using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AboutListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AboutCreate()
        {
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AboutCreate(AboutCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/About", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AboutList", "About");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("AboutList", "About");
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AboutUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5255/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<AboutUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AboutUpdate(AboutUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5255/api/About", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AboutList", "About");
                }
                // Güncelleme başarısız mesajı
                return RedirectToAction("AboutList", "About");
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> AboutDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList", "About");
            }
            return RedirectToAction("AboutList", "About");
        }

    }
}