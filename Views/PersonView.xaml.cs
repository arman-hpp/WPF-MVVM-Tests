﻿using CommunityToolkit.Mvvm.DependencyInjection;
using WPF_MVVM_Tests.ViewModels;

namespace WPF_MVVM_Tests.Views
{
    public partial class PersonView
    {
        public PersonView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<PersonViewModel>();
        }
    }
}