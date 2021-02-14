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
using Microsoft.EntityFrameworkCore;

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
        [DisableRequestSizeLimit]
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

            video.UserId = LoggedUserId;
            video.UploadedAt = DateTime.Now;
            video.FileName = fileName;
            video.MimeType = file.ContentType;
            video.ThumbnailFileName = ffmpegHelper.ProvideOutputFilename(fileName);
            video.ThumbnailMimeType = FFMPEGHelper.THUMB_MIME_TYPE;

            DbContext.Videos.Add(video);
            DbContext.SaveChanges();

            return RedirectToAction("Watch", new { id = video.Id });
        }

        public IActionResult Watch(int id)
        {
            var video = DbContext.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            VoteEntity? vote;

            try
            {
                vote = LoggedUserId == null ? 
                    null : 
                    DbContext.Votes.Where(x => x.UserId == LoggedUserId && x.VideoId == video.Id).Single();
            } 
            catch(Exception)
            {
                vote = null;
            }

            return View(new WatchViewModel()
            {
                Video = video,
                VoteEntity = vote,
                RecommendedVideos = DbContext.Videos
                    .Include(x => x.User)
                    .Include(x => x.Votes)
                    .OrderByDescending(x => x.Votes.Count)
                    .ToList()
            });
        }

        public IActionResult Stream(int id)
        {
            var video = DbContext.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            try
            {
                var filePath = Path.Combine(Config.Parsed["Videos:StoredFilesPath"], video.FileName);
                return PhysicalFile(filePath, video.MimeType);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult Thumbnail(int id)
        {
            var video = DbContext.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            try
            {
                var filePath = Path.Combine(Config.Parsed["Videos:StoredThumbnailsPath"], video.ThumbnailFileName);
                return PhysicalFile(filePath, video.ThumbnailMimeType);
            } catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult Search(string query)
        {
            if (query == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var videos = DbContext.Videos
                .Include(x => x.User)
                .Where(x => x.Title.Contains(query))
                .ToList();

            return View(videos);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Vote([FromBody] VoteEntity newVote)
        {
            if (newVote == null || newVote.VideoId == 0)
            {
                return BadRequest();
            }

            var existingVote = DbContext
                .Votes
                .Where(vote => vote.UserId == LoggedUserId && vote.VideoId == newVote.VideoId)
                .FirstOrDefault();

            if (existingVote != null)
            {
                DbContext.Votes.Remove(existingVote);
            }

            newVote.UserId = LoggedUserId;
            DbContext.Add(newVote);
            DbContext.SaveChanges();

            return Ok();
        }

        private string? LoggedUserId
        {
            get
            {
                try
                {
                    var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                    return user == null ? null : user.Value;
                }
                catch
                {
                    return null;
                }
            }
        } 
    }
}
