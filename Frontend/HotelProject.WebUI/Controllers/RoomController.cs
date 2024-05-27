using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> RoomList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RoomListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpGet]
        public IActionResult RoomCreate()
        {
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> RoomCreate(RoomCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/Room", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("RoomList", "Room");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("RoomList", "Room");
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> RoomUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5255/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<RoomUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> RoomUpdate(RoomUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5255/api/Room", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("RoomList", "Room");
                }
                // Güncelleme başarısız mesajı
                return RedirectToAction("RoomList", "Room");
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> RoomDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("RoomList", "Room");
            }
            return RedirectToAction("RoomList", "Room");
        }

    }
}