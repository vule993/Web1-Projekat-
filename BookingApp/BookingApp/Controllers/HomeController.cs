using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Title = "Uloguj se";

            return View();
        }
        public ActionResult Logout()
        {
            ViewBag.Title = "Logout";

            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.Title = "Registruj se";

            return View();
        }

        public ActionResult Profil()
        {
            ViewBag.Title = "Profil";

            return View();
        }

        public ActionResult Korisnici()
        {
            ViewBag.Title = "Spisak korisnika";

            return View();
        }

        public ActionResult DodajApartman()
        {
            ViewBag.Title = "Dodaj apartman";

            return View();
        }

        public ActionResult Apartman()
        {
            ViewBag.Title = "Apartman";

            return View();
        }

    }
}
