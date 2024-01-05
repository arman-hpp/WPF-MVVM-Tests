using System.Windows.Controls;

namespace WPF_MVVM_Tests.Services
{
    public interface IStepNavigationService
    {
        void NavigateTo(string pageUri);

        void GoBack();

        void RegisterFrame(Frame frame);
    }

    public class StepNavigationService : IStepNavigationService
    {
        private Frame _mainFrame;

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
