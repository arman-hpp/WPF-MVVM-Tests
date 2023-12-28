using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class PersonViewModel : BaseViewModel<Person>
    {
        public ICommand SaveCommand { get; init; }

        public PersonViewModel()
        {
            SaveCommand = new RelayCommand(Save, () => Model != null);
        }

        private void Save()
        {
            var f = Model.FullName;
        }
    }
}
