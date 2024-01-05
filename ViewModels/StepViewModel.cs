using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Controls;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class StepViewModel : BaseViewModel
    {

    }

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

    public interface IStepNavigationService
    {
        void NavigateTo(string pageUri);

        void GoBack();

        void RegisterFrame(Frame frame);
    }

    public class StepNavigationService : IStepNavigationService
    {
        private Frame _mainFrame;

        //public StepNavigationService(Frame mainFrame)
        //{
        //    _mainFrame = mainFrame;
        //}

        public void RegisterFrame(Frame frame)
        {
            _mainFrame = frame;
        }

        public void NavigateTo(string pageUri)
        {
            _mainFrame.NavigationService.Navigate(new Uri(pageUri, UriKind.RelativeOrAbsolute));
        }

        public void GoBack()
        {
            _mainFrame.GoBack();
        }
    }
}
