using System.Collections;
using System.ComponentModel;
using WPF_MVVM_Tests.Helpers;

namespace WPF_MVVM_Tests.Models
{
    public class BaseEntity : INotifyPropertyChanged, INotifyDataErrorInfo, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
            }
        }

        protected virtual void OnErrorsChanged(string propertyName = null)
        {
            if (ErrorsChanged != null)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName)));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return null;
        }

        public bool HasErrors { get; }
        
        public string Error { get; }

        public string this[string columnName] => throw new NotImplementedException();
    }
}
