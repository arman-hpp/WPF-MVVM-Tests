using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Tests.Services;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class Page2ViewModel : BaseViewModel
    {
        private readonly IStepNavigationService _navigationService;

        public RelayCommand NavigateCommand { get; }

        public RelayCommand GoBackCommand { get; }

        public Page2ViewModel(IStepNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand(NavigateToPage3);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private void NavigateToPage3()
        {
            _navigationService.NavigateTo("Views/Pages/Page3.xaml");
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }

}
