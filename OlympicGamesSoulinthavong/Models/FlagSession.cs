using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OlympicGamesSoulinthavong.Models
{
    public class FlagSession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countriescount";
        private const string OlympicGameKey = "game";
        private const string SportKey = "sport";

        private ISession session { get; set; }
        public FlagSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }
        public List<Country> GetMyCountries() => session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey) ?? 0;

        public void SetActiveOlympicGame(string activeOlympicGame) => session.SetString(OlympicGameKey, activeOlympicGame);
        public string GetActiveOlympicGame() => session.GetString(OlympicGameKey);

        public void SetActiveSport(string activeSport) => session.SetString(SportKey, activeSport);
        public string GetActiveSport() => session.GetString(SportKey);

        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }
}
