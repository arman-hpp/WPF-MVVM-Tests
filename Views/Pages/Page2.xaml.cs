using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views.Pages
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetRequiredService<Page2ViewModel>();
        }
    }
}
