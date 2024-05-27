using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LİSTELEME --------------------------------------------------------------------------
        public async Task<IActionResult> ContactList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Farklı bir API consume ettik. API'den mesaj count bilgisini aldık.
                var responseMessage2 = await client.GetAsync("http://localhost:5255/api/Contact/GetContactCount");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    // var values2 = JsonConvert.DeserializeObject<List<ContactListDto>>(jsonData2);
                    ViewBag.messageCount = jsonData2;
                }
                // ARA İŞLEM SONU --------------------------------------------------

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ContactListDto>>(jsonData).OrderByDescending(i => i.ContactDate).ToList();
                return View(values);
            }
            return View();
        }

        // DETAY --------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> ContactUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5255/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ContactUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }

        // SİLME --------------------------------------------------------------------------
        public async Task<IActionResult> ContactDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5255/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactList", "Contact");
            }
            return RedirectToAction("ContactList", "Contact");
        }

        // CLIENT --------------------------------------------------------------------------
        public async Task<IActionResult> ContactClient()
        {
            // MESAJCATEGORY tablosu başlagıç
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5255/api/MessageCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MessageCategoryListDto>>(jsonData);
                ViewBag.messageCategory = values;
            }
            // MESAJCATEGORY tablosu bitiş
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactNewMessage(ContactCreateDto contactCreateDto)
        {
            if (ModelState.IsValid)
            {
                contactCreateDto.ContactDate = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(contactCreateDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5255/api/Contact", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ContactClient", "Contact");
                }
                // Ekleme başarısız mesajı
                return RedirectToAction("ContactClient", "Contact");
            }
            return RedirectToAction("ContactClient", "Contact");
        }
    
    }
}