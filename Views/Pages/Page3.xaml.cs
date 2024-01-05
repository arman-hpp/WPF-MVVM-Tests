using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views.Pages
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetRequiredService<Page3ViewModel>();
        }
    }
}
