using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesSoulinthavong.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set;}
        public string ActiveOlympicGame { get; set; } = "all";
        public string ActiveCategory { get; set; } = "all";
    }
}
