using AvaloniaTest.Models;
using AvaloniaTest.Services;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaTest.ViewModels
{
    public class CityListViewModel : ViewModelBase
    {
        private string _selectedCountry = string.Empty;
        public string SelectedCountry
        {
            get => _selectedCountry;
            private set => this.RaiseAndSetIfChanged(ref _selectedCountry, value);
        }

        public CityListViewModel(IEnumerable<Country> countries, IEnumerable<City> cities)
        {
            Countries = new ObservableCollection<Country>(countries);
            Cities = new ObservableCollection<City>(cities);
        }

        public ObservableCollection<Country> Countries { get; }
        public ObservableCollection<City> Cities { get; }
    }
}
