using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gombka.pl.Data;
using Gombka.pl.Models;
using Microsoft.EntityFrameworkCore;

namespace Gombka.pl.Controllers
{
    public class ChannelController : Controller
    {
        private readonly ApplicationDbContext DbContext;

        public ChannelController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [Route("/channel/{userId}")]
        public IActionResult Index(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = DbContext.Users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }

            var videos = DbContext.Videos
                .Include(x => User)
                .Where(x => x.User.Id == userId)
                .OrderByDescending(x => x.UploadedAt);

            return View(new ChannelViewModel() {
                Videos = videos,
                User = user
            });
        }
    }
}
