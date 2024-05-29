using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardRow1 : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DashboardRow1(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // CLIENT --------------------------------------------------------------------------
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // StaffCount Api
            var responseMessage1 = await client.GetAsync("http://localhost:5255/api/DashboardWidget/StaffCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                ViewBag.staffCount = jsonData;
            }

            // BookingCount Api
            var responseMessage2 = await client.GetAsync("http://localhost:5255/api/DashboardWidget/BookingCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.bookingCount = jsonData;
            }

            // BookingCount Api
            var responseMessage3 = await client.GetAsync("http://localhost:5255/api/DashboardWidget/AppUserCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.appUserCount = jsonData;
            }

            // RoomCount Api
            var responseMessage4 = await client.GetAsync("http://localhost:5255/api/DashboardWidget/RoomCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.roomCount = jsonData;
            }

            return View();
        }
    }
}