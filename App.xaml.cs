using WPF_MVVM_Tests.Helpers;

namespace WPF_MVVM_Tests
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            DispatcherHelper.Initialize();
        }
    }
}
