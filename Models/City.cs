using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaTest.Models
{
    public class City : ReactiveObject
    {
        [Reactive]
        public int CityId { get; set; }

        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public int CountryId { get; set; }
    }
}
