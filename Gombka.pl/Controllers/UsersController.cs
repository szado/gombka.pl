using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gombka.pl.Models.Entities;
using Gombka.pl.Data;
using System;

namespace Gombka.pl.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public UsersController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: UsersController
        [Route("users/login")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("users/login")]
        public ActionResult Authenticate(UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: UsersController/Create
        [Route("users/register")]
        public ActionResult Register()
        {
            return View("Create");
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("users/register")]
        public ActionResult Create(UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", user);
            }

            try
            {
                user.Password = HashPassword(user.Password);

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Coś poszło nie tak, spróbuj ponownie.");

                return View("Create", user);
            }
        }

        // GET: UsersController/Edit/5
        [Route("users/account")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        protected string HashPassword(string password)
        {
            // temporary to check if hashing is properly done
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        //        if (!BCrypt.Net.BCrypt.Verify(password, hash))
        //{
        //    return false;
        //}
    }
}
