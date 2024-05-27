using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Web.Models;

namespace RapidApiConsume.Web.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index(DateTime checkin, DateTime checkout)
        {
            if (checkin > DateTime.Now && checkout > DateTime.Now.AddDays(1))
            {
                var giris = checkin.ToString("yyyy-MM-dd");
                var cikis = checkout.ToString("yyyy-MM-dd");

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/stays/search?locationId=eyJjaXR5X25hbWUiOiJOZXcgWW9yayIsImNvdW50cnkiOiJVbml0ZWQgU3RhdGVzIiwiZGVzdF9pZCI6IjIwMDg4MzI1IiwiZGVzdF90eXBlIjoiY2l0eSJ9&checkinDate={giris}&checkoutDate={cikis}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "f2f44c934dmshe07f0a09554c0a1p18783fjsnbd199f9b1d35" },
                        { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var bookingModel = JsonConvert.DeserializeObject<BookingModel>(body);
                    return View(bookingModel);
                }
            } else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/stays/search?locationId=eyJjaXR5X25hbWUiOiJOZXcgWW9yayIsImNvdW50cnkiOiJVbml0ZWQgU3RhdGVzIiwiZGVzdF9pZCI6IjIwMDg4MzI1IiwiZGVzdF90eXBlIjoiY2l0eSJ9&checkinDate={DateTime.Now.ToString("yyyy-MM-dd")}&checkoutDate={DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "f2f44c934dmshe07f0a09554c0a1p18783fjsnbd199f9b1d35" },
                        { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var bookingModel = JsonConvert.DeserializeObject<BookingModel>(body);
                    return View(bookingModel);
                }
            }
        }
    }
}