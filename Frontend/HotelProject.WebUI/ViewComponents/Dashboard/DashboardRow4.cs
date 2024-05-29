using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardRow4 : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DashboardRow4(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // CLIENT --------------------------------------------------------------------------
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/followers?username_or_id_or_url=instagram"),
                Headers =
                {
                    { "x-rapidapi-key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                    { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<InstagramRapidApiFollowersModel>(body);
                ViewBag.instagramFollowers = model.data.total.ToString().Substring(0,3)+"Mn";
            }

            // var client = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/following?username_or_id_or_url=instagram"),
                Headers =
                {
                    { "x-rapidapi-key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                    { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<InstagramRapidApiFollowingModel>(body);
                ViewBag.instagramFollowings = model.data.total;
            }

            return View();
        }
    }
}