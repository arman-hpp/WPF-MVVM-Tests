using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF_MVVM_Tests.Helpers;
using WPF_MVVM_Tests.Services;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherHelper.Initialize();

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<PersonViewModel>()
                    .AddSingleton<PeopleViewModel>()
                    .AddSingleton<StepViewModel>()
                    .AddSingleton<IStepNavigationService, StepNavigationService>()
                    .AddSingleton<Page1ViewModel>()
                    .AddSingleton<Page2ViewModel>()
                    .AddSingleton<Page3ViewModel>()
                    .BuildServiceProvider()
            );
        }
    }
}
