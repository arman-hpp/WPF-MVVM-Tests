using CommunityToolkit.Mvvm.DependencyInjection;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views
{
    public partial class PeopleView
    {
        public PeopleView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<PeopleViewModel>();
        }
    }
}
