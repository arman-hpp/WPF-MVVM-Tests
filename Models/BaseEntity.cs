using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WPF_MVVM_Tests.Helpers;

namespace WPF_MVVM_Tests.Models
{
    public class BaseEntity : INotifyPropertyChanged, IDataErrorInfo, INotifyDataErrorInfo, IValidate
    {
        private readonly ValidationTemplate _validationTemplate;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseEntity()
        {
            _validationTemplate = new ValidationTemplate(this);
            _validationTemplate.ErrorsChanged += OnErrorsChanged;
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public string this[string columnName] => _validationTemplate[columnName];

        public string Error => _validationTemplate.Error;

        public IEnumerable GetErrors(string propertyName)
        {
            return _validationTemplate.GetErrors(propertyName);
        }

        public bool HasErrors => _validationTemplate.HasErrors;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
            }
        }

        public void Validate()
        {
            _validationTemplate.Validate();
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //protected virtual void OnPropertyChanged(string propertyName = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        DispatcherHelper.CheckBeginInvokeOnUI(() =>
        //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
        //    }
        //}

        //protected virtual void OnErrorsChanged(string propertyName = null)
        //{
        //    if (ErrorsChanged != null)
        //    {
        //        DispatcherHelper.CheckBeginInvokeOnUI(() =>
        //            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName)));
        //    }
        //}

    }

    public interface IValidate
    {
        void Validate();
    }

    public class ValidationTemplate : IDataErrorInfo, INotifyDataErrorInfo, IValidate
    {
        private readonly INotifyPropertyChanged _target;
        private readonly ValidationContext _validationContext;
        private readonly List<ValidationResult> _validationResults;

        public ValidationTemplate(INotifyPropertyChanged target)
        {
            _target = target;
            _validationContext = new ValidationContext(target, null, null);
            _validationResults = new List<ValidationResult>();
            //Validator.TryValidateObject(target, _validationContext, _validationResults, true);
            target.PropertyChanged += Validate;
        }

        public void Validate()
        {
            _validationResults.Clear();
            Validator.TryValidateObject(_target, _validationContext, _validationResults, true);
            var hashSet = new HashSet<string>(_validationResults.SelectMany(x => x.MemberNames));
            foreach (var error in hashSet)
            {
                RaiseErrorsChanged(error);
            }
        }

        private void Validate(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == null)
                return;
            
            var propertyInfo = _target.GetType().GetProperty(e.PropertyName);
            if(propertyInfo == null)
                return;

            if(propertyInfo.CanWrite == false)
                return;

            var propVal = propertyInfo.GetValue(_target);

            _validationResults.Clear();
            var context = new ValidationContext(_target) { MemberName = e.PropertyName };
            Validator.TryValidateProperty(propVal, context, _validationResults);
            var hashSet = new HashSet<string>(_validationResults.SelectMany(x => x.MemberNames));
            foreach (var error in hashSet)
            {
                RaiseErrorsChanged(error);
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _validationResults
                .Where(x => x.MemberNames.Contains(propertyName))
                .Select(x => x.ErrorMessage);
        }

        public bool HasErrors => _validationResults.Count > 0;

        public string Error
        {
            get
            {
                var strings = _validationResults
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                return string.Join(Environment.NewLine, strings);
            }
        }

        public string this[string propertyName]
        {
            get
            {
                var strings = _validationResults
                    .Where(x => x.MemberNames.Contains(propertyName))
                    .Select(x => x.ErrorMessage)
                    .ToArray();
                return string.Join(Environment.NewLine, strings);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
