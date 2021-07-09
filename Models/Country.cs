using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaTest.Models
{
    public class Country : ReactiveObject
    {
        [Reactive]
        public int CountryId { get; set; }

        [Reactive]
        public string Name { get; set; }
    }
}
