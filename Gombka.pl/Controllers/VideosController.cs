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
using Gombka.pl.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Gombka.pl.Controllers
{
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext DbContext;
        private readonly Config Config;
        private FFMPEGHelper ffmpegHelper;

        public VideosController(ApplicationDbContext applicationDbContext, Config config, FFMPEGHelper _ffmpegHelper)
        {
            DbContext = applicationDbContext;
            Config = config;
            ffmpegHelper = _ffmpegHelper;
        }

        public IActionResult Index()
        {
            return Json("tu wszytskie filmy");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            var viewModel = new UploadViewModel();
            viewModel.Categories = DbContext.Categories.ToList();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Upload(VideoEntity video, IFormFile file)
        {
            if (file == null)
            {
                ViewData["message"] = "Wybierz plik wideo.";
                return Upload();
            }

            if (file.Length == 0 || file.Length > Config.VideoMaxBytes)
            {
                ViewData["message"] = $"Nieprawidłowy rozmiar pliku. Maksymalna wielkość to {Config.VideoMaxMb} MB.";
                return Upload();
            }

            if (!Config.AllowedVideoMimeTypes.Contains(file.ContentType))
            {
                ViewData["message"] = $"Nieobsługiwany typ pliku ({file.ContentType}).";
                return Upload();
            }

            var fileName = Path.GetRandomFileName();
            var filePath = Path.Combine(Config.Parsed["Videos:StoredFilesPath"], fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                file.CopyTo(stream);
            }

            ffmpegHelper.CreateThumbnailFromVideo(filePath, fileName);

            video.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            video.UploadedAt = DateTime.Now;
            video.FileName = fileName;
            video.MimeType = file.ContentType;
            video.ThumbnailFileName = fileName;

            DbContext.Videos.Add(video);
            DbContext.SaveChanges();


            return RedirectToAction("Watch", new { id = video.Id });
        }

        public IActionResult Watch(int id)
        {
            return Content($"<video src='/videos/stream/{id}' controls='controls'></video>", "text/html");
        }

        public IActionResult Stream(int id)
        {
            var video = DbContext.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(Config.Parsed["Videos:StoredFilesPath"], video.FileName);
            return PhysicalFile(filePath, video.MimeType);
        }
    }
}
