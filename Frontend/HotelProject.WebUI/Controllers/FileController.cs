using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class FileController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); // Akış oluşturuldu
            await file.CopyToAsync(stream); // Dosya kopyalandı
            var bytes = stream.ToArray(); // Akıştaki dosyayı byte olarak tuttuk

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType) ;
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpclient = new HttpClient();
            await httpclient.PostAsync("http://localhost:5255/api/File", multipartFormDataContent);

            return View();
        }
    }
}