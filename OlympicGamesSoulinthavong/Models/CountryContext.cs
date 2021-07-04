using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGamesSoulinthavong.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<OlympicGame> OlympicGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OlympicGame>().HasData(
                new OlympicGame { OlympicGameId = "wo", Name = "Winter Olympics" },
                new OlympicGame { OlympicGameId = "so", Name = "Summer Olympics" },
                new OlympicGame { OlympicGameId = "po", Name = "Paralympics" },
                new OlympicGame { OlympicGameId = "yo", Name = "Youth Olympics" }
                );

            modelBuilder.Entity<Sport>().HasData(
                new Sport
                {
                    SportId = "curl",
                    Name = "Curling",
                    Category = "Indoor"
                },
                new Sport
                {
                    SportId = "bob",
                    Name = "Bobsleigh",
                    Category = "Outdoor"
                },
                new Sport
                {
                    SportId = "div",
                    Name = "Diving",
                    Category = "Indoor"
                },
                new Sport
                {
                    SportId = "cycl",
                    Name = "Road Cycling",
                    Category = "Outdoor"
                },
                new Sport
                {
                    SportId = "arch",
                    Name = "Archery",
                    Category = "Indoor"
                },
                new Sport
                {
                    SportId = "cs",
                    Name = "Canoe Sprint",
                    Category = "Outdoor"
                },
                new Sport
                {
                    SportId = "break",
                    Name = "Breakdancing",
                    Category = "Indoor"
                },
                new Sport
                {
                    SportId = "skate",
                    Name = "Skateboarding",
                    Category = "Outdoor"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "can", Name = "Canada", OlympicGameId = "wo", SportId = "curl", LogoImage = "can.png" },
                new Country { CountryID = "se", Name = "Sweden", OlympicGameId = "wo", SportId = "curl", LogoImage = "se.png" },
                new Country { CountryID = "gb", Name = "Great Britain", OlympicGameId = "wo", SportId = "curl", LogoImage = "gb.png" },
                new Country { CountryID = "jam", Name = "Jamaica", OlympicGameId = "wo", SportId = "bob", LogoImage = "jam.png" },
                new Country { CountryID = "it", Name = "Italy", OlympicGameId = "wo", SportId = "bob", LogoImage = "it.png" },
                new Country { CountryID = "jp", Name = "Japan", OlympicGameId = "wo", SportId = "bob", LogoImage = "jp.png" },
                new Country { CountryID = "germ", Name = "Germany", OlympicGameId = "so", SportId = "div", LogoImage = "germ.png" },
                new Country { CountryID = "chi", Name = "China", OlympicGameId = "so", SportId = "div", LogoImage = "chi.png" },
                new Country { CountryID = "mex", Name = "Mexico", OlympicGameId = "so", SportId = "div", LogoImage = "mex.png" },
                new Country { CountryID = "braz", Name = "Brazil", OlympicGameId = "so", SportId = "cycl", LogoImage = "braz.png" },
                new Country { CountryID = "ne", Name = "Netherlands", OlympicGameId = "so", SportId = "cycl", LogoImage = "ne.png" },
                new Country { CountryID = "usa", Name = "USA", OlympicGameId = "so", SportId = "cycl", LogoImage = "usa.png" },
                new Country { CountryID = "thai", Name = "Thailand", OlympicGameId = "po", SportId = "arch", LogoImage = "thai.png" },
                new Country { CountryID = "ur", Name = "Uruguy", OlympicGameId = "po", SportId = "arch", LogoImage = "ur.png" },
                new Country { CountryID = "ukr", Name = "Ukraine", OlympicGameId = "po", SportId = "arch", LogoImage = "ukr.png" },
                new Country { CountryID = "aus", Name = "Austria", OlympicGameId = "po", SportId = "cs", LogoImage = "aus.png" },
                new Country { CountryID = "pak", Name = "Pakistan", OlympicGameId = "po", SportId = "cs", LogoImage = "pak.png" },
                new Country { CountryID = "zim", Name = "Zimbabwe", OlympicGameId = "po", SportId = "cs", LogoImage = "zim.png" },
                new Country { CountryID = "fran", Name = "France", OlympicGameId = "yo", SportId = "break", LogoImage = "fran.png" },
                new Country { CountryID = "cyp", Name = "Cyprus", OlympicGameId = "yo", SportId = "break", LogoImage = "cyp.png" },
                new Country { CountryID = "rus", Name = "Russia", OlympicGameId = "yo", SportId = "break", LogoImage = "rus.png" },
                new Country { CountryID = "fin", Name = "Finland", OlympicGameId = "yo", SportId = "skate", LogoImage = "fin.png" },
                new Country { CountryID = "slov", Name = "Slovakia", OlympicGameId = "yo", SportId = "skate", LogoImage = "slov.png" },
                new Country { CountryID = "port", Name = "Portugal", OlympicGameId = "yo", SportId = "skate", LogoImage = "port.png" }
            );
        }
    }
}
