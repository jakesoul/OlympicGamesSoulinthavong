using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesSoulinthavong.Models
{
    public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; }
        public OlympicGame OlympicGame { get; set; }
        public Sport Sport { get; set; }
        public string LogoImage { get; set; }
        public string OlympicGameId { get; set; }
        public string SportId { get; set; }
    }
}
