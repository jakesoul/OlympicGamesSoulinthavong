using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesSoulinthavong.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countries { get; set; }

        private List<OlympicGame> olympicGames;
        public List<OlympicGame> OlympicGames
        {
            get => olympicGames;
            set
            {
                olympicGames = value;
                olympicGames.Insert(0, new OlympicGame { OlympicGameId = "all", Name = "All" });
            }
        }

        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = value;
                sports.Insert(0, new Sport { SportId = "all", Name = "All" });
            }
        }

        // methods to help view determine active link
        public string CheckActiveOlympicGame(string g) => g.ToLower() == ActiveOlympicGame.ToLower() ? "active" : "";

        public string CheckActiveCategory(string c) => c.ToLower() == ActiveCategory.ToLower() ? "active" : "";
    }
}
