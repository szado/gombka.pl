using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gombka.pl.Controllers
{
    public class HelpController : Controller
    {
        [Route("/pomoc")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
