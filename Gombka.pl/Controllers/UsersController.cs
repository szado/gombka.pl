using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gombka.pl.Models;
using System.Linq;

namespace Gombka.pl.Controllers
{
    public class UsersController : Controller
    {
        private const int PASSWORD_LENGTH_MIN = 8;
        private const int PASSWORD_LENGTH_MAX = 32;
        private const int LOGIN_LENGTH_MIN = 3;
        private const int LOGIN_LENGTH_MAX = 16;

        // GET: UsersController
        [Route("users/login")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("users/login")]
        public ActionResult Authenticate([FromForm] LoginModel form)
        {
            if (!PasswordVerify(form.Password) || !LoginVerify(form.Login))
            {
                return View("Index", form);
            }

            return RedirectToAction("Index", "Home");
        }

        protected bool PasswordVerify(string password)
        {
            if (password.Length < PASSWORD_LENGTH_MIN || password.Length > PASSWORD_LENGTH_MAX)
            {
                return false;
            }

            if (password.Any(char.IsWhiteSpace))
            {
                return false;
            }

            // temporary to check if hashing is properly done
            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            if (!BCrypt.Net.BCrypt.Verify(password, hash))
            {
                return false;
            }

            return true;
        }

        protected bool LoginVerify(string login)
        {
            if (login.Length < LOGIN_LENGTH_MIN || login.Length > LOGIN_LENGTH_MAX)
            {
                return false;
            }

            if (!login.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("users/register")]
        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        [Route("users/account")]
        // GET: UsersController/Edit/5
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
    }
}
