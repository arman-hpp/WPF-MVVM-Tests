using CommunityToolkit.Mvvm.DependencyInjection;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<PersonViewModel>();
        }
    }
}