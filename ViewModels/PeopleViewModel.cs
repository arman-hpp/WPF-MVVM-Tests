using System.Collections.ObjectModel;
using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class PeopleViewModel : BaseViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }

        public Person SelectedPerson { get; set; }

        public PeopleViewModel()
        {
            Persons = new ObservableCollection<Person>
            {
                new("Arman", "Arian"),
                new("Ali", "Shafiei")
            };

            SelectedPerson = Persons[1];
        }
    }
}
