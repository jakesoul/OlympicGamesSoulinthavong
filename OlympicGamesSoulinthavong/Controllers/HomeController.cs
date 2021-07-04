using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OlympicGamesSoulinthavong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesSoulinthavong.Controllers
{

    public class HomeController : Controller
    {
        private CountryContext context;
        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeOlympicGame = "all", string activeCategory = "all")
        {
            var session = new FlagSession(HttpContext.Session);
            session.SetActiveOlympicGame(activeOlympicGame);
            session.SetActiveSport(activeCategory);

            //if no count in session, get cookie and restore favorite countries in session
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new FlagCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountriesIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                {
                    mycountries = context.Countries.Include(c => c.OlympicGame).Include(c => c.Sport).Where(c => ids.Contains(c.CountryID)).ToList();
                }
                session.SetMyCountries(mycountries);
            }
            var model = new CountryListViewModel
            {
                ActiveOlympicGame = activeOlympicGame,
                ActiveCategory = activeCategory,
                OlympicGames = context.OlympicGames.ToList(),
                Sports = context.Sports.ToList()
            };

            // get countries - filter by games and sport's categories
            IQueryable<Country> query = context.Countries;
            if (activeOlympicGame != "all")
                query = query.Where(
                    c => c.OlympicGame.OlympicGameId.ToLower() == activeOlympicGame.ToLower());
            if (activeCategory != "all")
                query = query.Where(
                    c => c.Sport.SportId.ToLower() == activeCategory.ToLower());
            model.Countries = query.ToList();
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Details(CountryViewModel model)
        {
            //Utility.LogCountryClick(model.Country.CountryID);
            TempData["ActiveOlympicGame"] = model.ActiveOlympicGame;
            TempData["ActiveCategory"] = model.ActiveCategory;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new FlagSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                Country = context.Countries.Include(c => c.OlympicGame).Include(c => c.Sport).FirstOrDefault(c => c.CountryID == id),
                ActiveOlympicGame = session.GetActiveOlympicGame(),
                ActiveCategory = session.GetActiveSport(),
            };
            
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries.Include(c => c.OlympicGame).Include(c => c.Sport).Where(c => c.CountryID == model.Country.CountryID).FirstOrDefault();

            var session = new FlagSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new FlagCookies(Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveOlympicGame = session.GetActiveOlympicGame(),
                    ActiveCategory = session.GetActiveSport()
                });
        }
    }
}
