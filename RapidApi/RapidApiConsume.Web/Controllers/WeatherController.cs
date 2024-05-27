using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Web.Models;

namespace RapidApiConsume.Web.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=Ankara&format=json&u=f"),
                Headers =
                {
                    { "X-RapidAPI-Key", "f2f44c934dmshe07f0a09554c0a1p18783fjsnbd199f9b1d35" },
                    { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(body);
                return View(weatherModel);
            }
        }
    }
}