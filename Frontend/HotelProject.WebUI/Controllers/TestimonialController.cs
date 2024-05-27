using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> TestimonialList()
        {
            // API'nin CONSUME edilmesi

            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.GetAsync("http://localhost:5255/api/Testimonial"); // http adresine istekte bulunduk

            if (responseMessage.IsSuccessStatusCode) // Başarılı sonuç dönerse (200lü kodlardan herhangi biri)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen veriyi değişkene atadık
                var values = JsonConvert.DeserializeObject<List<TestimonialListModel>>(jsonData); // Gelen Json türü veriyi DESERIALIZE ederek, tabloda gösterebileceğimiz formata dönüştürdük
                return View(values);
            }

            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(TestimonialCreateModel model)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var jsonData = JsonConvert.SerializeObject(model); // Gelen veriyi SERIALIZE ederek, Json formatına dönüştürdük

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // jsonData verisini stringContent içine gönderdik

            var responseMessage = await client.PostAsync("http://localhost:5255/api/Testimonial", stringContent); // stringContent verisini, client'a post ettik

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> TestimonialUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.GetAsync($"http://localhost:5255/api/Testimonial/{id}"); // http adresine istekte bulunduk

            if (responseMessage.IsSuccessStatusCode) // Başarılı sonuç dönerse (200lü kodlardan herhangi biri)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen veriyi değişkene atadık
                var value = JsonConvert.DeserializeObject<TestimonialUpdateModel>(jsonData); // Gelen Json türü veriyi DESERIALIZE ederek, tabloda gösterebileceğimiz formata dönüştürdük
                return View(value);
            }

            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> TestimonialUpdate(TestimonialUpdateModel model)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var jsonData = JsonConvert.SerializeObject(model); // Gelen veriyi SERIALIZE ederek, Json formatına dönüştürdük

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // jsonData verisini stringContent içine gönderdik

            var responseMessage = await client.PutAsync("http://localhost:5255/api/Testimonial", stringContent); // stringContent verisini, client'a put ettik

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> TestimonialDelete(int id)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Testimonial/{id}"); // Gelen id'yi, Delete'e gönderdik

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return RedirectToAction("TestimonialList", "Testimonial");
        }
    
    }
}