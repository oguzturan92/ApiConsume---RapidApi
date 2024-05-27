using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class WorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> WorkLocationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/WorkLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WorkLocationListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpGet]
        public IActionResult WorkLocationCreate()
        {
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> WorkLocationCreate(WorkLocationCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/WorkLocation", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("WorkLocationList", "WorkLocation");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("WorkLocationList", "WorkLocation");
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> WorkLocationUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5255/api/WorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WorkLocationUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> WorkLocationUpdate(WorkLocationUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5255/api/WorkLocation", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("WorkLocationList", "WorkLocation");
                }
                // Güncelleme başarısız mesajı
                return RedirectToAction("WorkLocationList", "WorkLocation");
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> WorkLocationDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/WorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WorkLocationList", "WorkLocation");
            }
            return RedirectToAction("WorkLocationList", "WorkLocation");
        }

    }
}