using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Gombka.pl.Models;
using Gombka.pl.Models.Entities;
using Gombka.pl.Data;
using System.Security.Claims;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Gombka.pl.Controllers
{
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext DbContext;
        private readonly IConfiguration Configuration;

        public VideosController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            DbContext = applicationDbContext;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return Json("tu wszytskie filmy");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            var viewModel = new UploadViewModel();
            viewModel.Categories = DbContext.Categories.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Upload(VideoEntity video, IFormFile file)
        {
            if (file == null)
            {
                ViewData["message"] = "Wybierz plik wideo.";
                return Upload();
            }

            if (file.Length == 0 || file.Length > 100_000_000)
            {
                ViewData["message"] = "Nieprawidłowy rozmiar pliku. Maksymalna wielkość to 100 MB.";
                return Upload();
            }

            var fileName = Path.GetRandomFileName();
            var filePath = Path.Combine(Configuration["StoredFilesPath"], fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                file.CopyTo(stream);
            }

            video.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            video.FileName = fileName;
            DbContext.Videos.Add(video);
            DbContext.SaveChanges();
            return RedirectToAction("Watch", new { videoId = video.Id });
        }

        public IActionResult Watch(int videoId)
        {
            return Json($"odtwarzanie filmu {videoId}");
        }
    }
}
