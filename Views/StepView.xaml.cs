using CommunityToolkit.Mvvm.DependencyInjection;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views
{
    public partial class StepView
    {
        public StepView()
        {
            InitializeComponent();

            var navigationService = Ioc.Default.GetRequiredService<IStepNavigationService>();
            navigationService.RegisterFrame(FmMain);
        }
    }
}
