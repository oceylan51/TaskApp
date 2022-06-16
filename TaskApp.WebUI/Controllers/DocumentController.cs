using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.Entity;
using TaskApp.WebUI.Identity;
using TaskApp.WebUI.Models;

namespace TaskApp.WebUI.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private IDocumentService _documentService;
        private UserManager<User> _userManager;

        public DocumentController(IDocumentService documentService, UserManager<User> userManager)
        {
            _documentService = documentService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_documentService.GetNotDeletedDocument());
        }
        public IActionResult AddDocument()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDocument(IFormFile file, AddDocumentModel model)
        {
            if (file != null && file.ContentType == "image/png")
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{model.ImageUrl}.png");
                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                Document document = new Document()
                {
                    ImageUrl = model.ImageUrl + ".png",
                    DocumentTitle = model.DocumentTitle,
                    AddedById = _userManager.GetUserId(User)
                };
                _documentService.Create(document);
                return RedirectToAction("Index");
            }
            ViewBag.Result = "Fill in the information completely";
            return View();
        }
        public IActionResult DocumentDelete(int id)
        {
            _documentService.DocumentDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeletedDocumentList()
        {
            return View(_documentService.GetDeletedDocument());
        }
        public IActionResult AddDeletedBack(int id)
        {
            _documentService.AddDeletedBack(id);
            return RedirectToAction("Index");
        }
    }
}

