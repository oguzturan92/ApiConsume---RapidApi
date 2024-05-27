using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Web.Models;

namespace RapidApiConsume.Web.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Bu alannı Rapid Api sitesinden aldık
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "X-RapidAPI-Key", "f2f44c934dmshe07f0a09554c0a1p18783fjsnbd199f9b1d35" },
                    { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Bu alanı biz ekledik. Gelen json veriyi nesne'ye dönüştürdük ve view'e gönderdik.
                var imdbModel = JsonConvert.DeserializeObject<List<ImdbModel>>(body);
                return View(imdbModel);
            }
        }
    }
}