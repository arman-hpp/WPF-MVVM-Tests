using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views.Pages
{
    public partial class Page1 : Page
    {
      //  private readonly Page1ViewModel _viewModel;

        public Page1()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetRequiredService<Page1ViewModel>();
        }
    }
}
