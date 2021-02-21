using AvaloniaTest.Models;
using System.Collections.Generic;

namespace AvaloniaTest.Services
{
    public class Database
    {
        public static IEnumerable<Country> GetCountries() => new[]
        {
            new Country { CountryId = 1, Name = "Belgium" },
            new Country { CountryId = 2, Name = "France" },
            new Country { CountryId = 3, Name = "The Netherlands" },
            new Country { CountryId = 4, Name = "United Kingdom" },
            new Country { CountryId = 5, Name = "United States" }
        };

        public static IEnumerable<City> GetCities() => new[]
        {
            new City { CityId = 1, Name = "Antwerp", CountryId = 1 },
            new City { CityId = 2, Name = "Brussels", CountryId = 1 },
            new City { CityId = 3, Name = "Paris" , CountryId = 2 },
            new City { CityId = 4, Name = "Amsterdam", CountryId = 3},
            new City { CityId = 5, Name = "Utrecht", CountryId = 3},
            new City { CityId = 6, Name = "London", CountryId = 4 }
        };
    }
}
