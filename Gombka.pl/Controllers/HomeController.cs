using Gombka.pl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Data;
using Microsoft.EntityFrameworkCore;

namespace Gombka.pl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext DbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            DbContext = dbContext;
        }

        public IActionResult Index()
        {
            var videos = DbContext.Videos
                .Include(x => x.User)
                .Include(x => x.Votes)
                .OrderByDescending(x => x.UploadedAt)
                .Take(10)
                .ToList();

            return View(videos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
