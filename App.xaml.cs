using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF_MVVM_Tests.Helpers;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<PersonViewModel>()
                    .BuildServiceProvider());
        }
    }
}
