using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Tests.Services;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class Page3ViewModel : BaseViewModel
    {
        private readonly IStepNavigationService _navigationService;

        public RelayCommand GoBackCommand { get; }

        public Page3ViewModel(IStepNavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new RelayCommand(GoBack);
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
