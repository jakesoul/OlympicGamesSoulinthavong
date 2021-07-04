using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OlympicGamesSoulinthavong.Models
{
    public class FlagCookies
    {
        private const string MyCountries = "mycountries";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public FlagCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public FlagCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyCountryIds(List<Country> mycountries)
        {
            List<string> ids = mycountries.Select(c => c.CountryID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyCountryIds();
            responseCookies.Append(MyCountries, idsString, options);
        }

        public string[] GetMyCountriesIds()
        {
            string cookie = requestCookies[MyCountries];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { };
            else
                return cookie.Split(Delimiter);
        }

        public void RemoveMyCountryIds()
        {
            responseCookies.Delete(MyCountries);
        }
    }
}
