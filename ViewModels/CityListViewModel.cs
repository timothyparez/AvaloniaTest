﻿using Avalonia.Controls;
using AvaloniaTest.Models;
using AvaloniaTest.Services;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace AvaloniaTest.ViewModels
{
    public class CityListViewModel : ViewModelBase
    {
        [Reactive]
        public Country SelectedCountry { get; set; }
        
        private SourceCache<Country, int> _countryCache = new SourceCache<Country, int>(x => x.CountryId);
        public ReadOnlyObservableCollection<Country> Countries => _countries;
        private readonly ReadOnlyObservableCollection<Country> _countries;


        private SourceCache<City, int> _cityCache = new SourceCache<City, int>(x => x.CityId);
        public ReadOnlyObservableCollection<City> Cities => _cities;
        private readonly ReadOnlyObservableCollection<City> _cities;

        private readonly IDisposable _countryCleanUp;
        private readonly IDisposable _cityCleanUp;

        public CityListViewModel(IEnumerable<Country> countries, IEnumerable<City> cities)
        {
            _countryCache.AddOrUpdate(countries);

            _countryCleanUp = _countryCache.Connect()
                .Bind(out _countries)
                .DisposeMany()
                .Subscribe();

            _cityCache.AddOrUpdate(cities);

            // This is to pre-fill the selection with a default to test the combobox
            SelectedCountry = countries.First(); 
            
            /* Original code:
             * SelectedCountry = new Country { CountryId = 3, Name = "The Netherlands" };
             * The ComboBox is bound to Countries, but here a new instance is assigned which is not part of the list */

            //Search logic
            Func<City, bool> cityFilter(Country country) => city =>
            {
                return country == null || city.CountryId == SelectedCountry.CountryId;
            };

            var filterPredicate = this.WhenAnyValue(x => x.SelectedCountry)
                                      .Throttle(TimeSpan.FromMilliseconds(250), RxApp.TaskpoolScheduler)
                                      .DistinctUntilChanged()
                                      .Select(cityFilter);

            _cityCleanUp = _cityCache.Connect()
                .Filter(filterPredicate)
                .Bind(out _cities)
                .DisposeMany()
                .Subscribe();
        }

        public void Dispose()
        {
            _countryCleanUp.Dispose();
            _cityCleanUp.Dispose();
        }
    }
}
