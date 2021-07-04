using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OlympicGamesSoulinthavong.Models;

namespace OlympicGamesSoulinthavong.Controllers
{
    public class Favorites : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new FlagSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveOlympicGame = session.GetActiveOlympicGame(),
                ActiveCategory = session.GetActiveSport(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new FlagSession(HttpContext.Session);
            var cookies = new FlagCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveOlympicGame = session.GetActiveOlympicGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}
