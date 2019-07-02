using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KabiLottery2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Game()
        {
            ViewBag.Message = "Start Game";
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}