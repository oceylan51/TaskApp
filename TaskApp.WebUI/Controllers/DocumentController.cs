using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.WebUI.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDocument()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDocument(IFormFile file, string documentName)
        {

            if (file != null && file.ContentType == "image/png")
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{documentName}");
                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
            }
            return View();
        }
    }
}
