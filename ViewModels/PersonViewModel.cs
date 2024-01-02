using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class PersonViewModel : BaseViewModel
    {
        public ObservableObject<Person> Person { get; init; }

        public ICommand SaveCommand { get; init; }

        public PersonViewModel()
        {
            Person = new ObservableObject<Person>(new Person());
            SaveCommand = new RelayCommand(Save, () => true);
        }

        //private void Save()
        //{
        //    var f = Model.FullName;
        //}

        private void Save()
        {
            if (Person.Properties.HasErrors)
            {

            }

            Person.Properties.Validate();

            if (Person.Properties.HasErrors)
            {

            }

            var f = Person.Properties.FullName;
        }
    }
}
