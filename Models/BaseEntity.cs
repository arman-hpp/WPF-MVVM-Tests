using System.ComponentModel;
using WPF_MVVM_Tests.Helpers;

namespace WPF_MVVM_Tests.Models
{
    public class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
            }
        }
    }
}
