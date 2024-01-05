using CommunityToolkit.Mvvm.Input;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class Page1ViewModel : BaseViewModel
    {
        private readonly IStepNavigationService _navigationService;

        public RelayCommand NavigateCommand { get; }

        public Page1ViewModel(IStepNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand(NavigateToPage2);
        }

        private void NavigateToPage2()
        {
            _navigationService.NavigateTo("Views/Pages/Page2.xaml");
        }
    }

}
