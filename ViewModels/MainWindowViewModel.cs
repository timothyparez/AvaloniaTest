using AvaloniaTest.Services;
using ReactiveUI;

namespace AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Database db)
        {
            List = new CityListViewModel(Database.GetCountries(), Database.GetCities());
        }

        public CityListViewModel List { get; }
    }
}
