using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookingList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingListDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> BookingUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5255/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BookingUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> BookingUpdate(BookingUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5255/api/Booking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookingList", "Booking");
                }
                // Güncelleme başarısız mesajı
                return RedirectToAction("BookingList", "Booking");
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> BookingDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookingList", "Booking");
            }
            return RedirectToAction("BookingList", "Booking");
        }

        // CLIENT METOTLARI -----------------------------------------------------------------------------
        public IActionResult BookingClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingCreate(BookingCreateDto bookingCreateDto)
        {
            // if (ModelState.IsValid)
            // {
                bookingCreateDto.BookingStatus = "Onay Bekliyor";
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(bookingCreateDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/Booking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("Index", "Home");
            // }
            // return RedirectToAction("BookingClient", "Home");
        }
        
    }
}