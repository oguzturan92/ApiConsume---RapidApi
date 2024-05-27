using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> ServiceList()
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.GetAsync("http://localhost:5255/api/Service"); // http adresine istekte bulunduk

            if (responseMessage.IsSuccessStatusCode) // Başarılı sonuç dönerse (200lü kodlardan herhangi biri)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen veriyi değişkene atadık
                var values = JsonConvert.DeserializeObject<List<ServiceListDto>>(jsonData); // Gelen Json türü veriyi DESERIALIZE ederek, tabloda gösterebileceğimiz formata dönüştürdük
                return View(values);
            }

            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpGet]
        public IActionResult ServiceCreate()
        {
            return View();
        }

        // EKLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> ServiceCreate(ServiceCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

                var jsonData = JsonConvert.SerializeObject(model); // Gelen veriyi SERIALIZE ederek, Json formatına dönüştürdük

                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // jsonData verisini stringContent içine gönderdik

                var responseMessage = await client.PostAsync("http://localhost:5255/api/Service", stringContent); // stringContent verisini, client'a post ettik

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ServiceList", "Service");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("ServiceList", "Service");
            }
            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> ServiceUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.GetAsync($"http://localhost:5255/api/Service/{id}"); // http adresine istekte bulunduk

            if (responseMessage.IsSuccessStatusCode) // Başarılı sonuç dönerse (200lü kodlardan herhangi biri)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen veriyi değişkene atadık
                var value = JsonConvert.DeserializeObject<ServiceUpdateDto>(jsonData); // Gelen Json türü veriyi DESERIALIZE ederek, tabloda gösterebileceğimiz formata dönüştürdük
                return View(value);
            }

            return View();
        }

        // GÜNCELLEME --------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> ServiceUpdate(ServiceUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

                var jsonData = JsonConvert.SerializeObject(model); // Gelen veriyi SERIALIZE ederek, Json formatına dönüştürdük

                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // jsonData verisini stringContent içine gönderdik

                var responseMessage = await client.PutAsync("http://localhost:5255/api/Service", stringContent); // stringContent verisini, client'a put ettik

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ServiceList", "Service");
                }
                // Güncelleme başarısız mesajı
                return RedirectToAction("ServiceList", "Service");
            }

            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> ServiceDelete(int id)
        {
            var client = _httpClientFactory.CreateClient(); // İstemci oluşturduk

            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Service/{id}"); // Gelen id'yi, Delete'e gönderdik

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceList", "Service");
            }

            return RedirectToAction("ServiceList", "Service");
        }

    }
}