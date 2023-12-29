﻿using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    //public sealed class PersonViewModel : BaseViewModel<Person>
    //{
    //    public ICommand SaveCommand { get; init; }

    //    public PersonViewModel()
    //    {
    //        SaveCommand = new RelayCommand(Save, () => Model != null);
    //    }

    //    private void Save()
    //    {
    //        var f = Model.FullName;
    //    }
    //}

    //public sealed class PersonViewModel
    //{
    //    public BaseViewModel<Person> Person { get; set; }

    //    public ICommand SaveCommand { get; init; }

    //    public PersonViewModel()
    //    {
    //        Person = new BaseViewModel<Person>();
    //        SaveCommand = new RelayCommand(Save, () => true);
    //    }

    //    //private void Save()
    //    //{
    //    //    var f = Model.FullName;
    //    //}

    //    private void Save()
    //    {
    //        var f = Person.Model.FullName;
    //    }
    //}

    public sealed class PersonViewModel
    {
        public ObservableObject<Person> Person { get; set; }

        public ICommand SaveCommand { get; init; }

        public PersonViewModel()
        {
            Person = new ObservableObject<Person>();
            SaveCommand = new RelayCommand(Save, () => true);
        }

        //private void Save()
        //{
        //    var f = Model.FullName;
        //}

        private void Save()
        {
            var f = Person.Properties.FullName;
        }
    }
}
