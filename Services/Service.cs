using AvaloniaTest.Models;
using DynamicData;
using System;

namespace AvaloniaTest.Services
{
    public class Service
    {
        private readonly SourceList<City> _cities = new SourceList<City>();

        public IObservable<IChangeSet<City>> Connect() => _cities.Connect();

        public Service()
        {
            _cities.Add(new City { CityId = 1, Name = "Antwerp", CountryId = 1 });
            _cities.Add(new City { CityId = 2, Name = "Brussels", CountryId = 1 });
            _cities.Add(new City { CityId = 3, Name = "Paris", CountryId = 2 });
            _cities.Add(new City { CityId = 4, Name = "Amsterdam", CountryId = 3 });
            _cities.Add(new City { CityId = 5, Name = "Utrecht", CountryId = 3 });
            _cities.Add(new City { CityId = 6, Name = "London", CountryId = 4 });
        }
    }
}
