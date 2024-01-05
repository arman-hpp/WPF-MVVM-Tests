using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WPF_MVVM_Tests.Helpers;

namespace WPF_MVVM_Tests.Models
{
    public abstract class BaseEntity : INotifyPropertyChanged, IDataErrorInfo, INotifyDataErrorInfo, IValidateEntity
    {
        private readonly ValidationTemplate _validationTemplate;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseEntity()
        {
            _validationTemplate = new ValidationTemplate(this);
            _validationTemplate.ErrorsChanged += OnRaiseError;
        }

        private void OnRaiseError(object sender, DataErrorsChangedEventArgs e)
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
    }

    public interface IValidateEntity
    {
        void Validate();
    }

    public sealed class ValidationTemplate : IDataErrorInfo, INotifyDataErrorInfo, IValidateEntity
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
            ClearErrors();
            Validator.TryValidateObject(_target, _validationContext, _validationResults, true);
            var errors = new HashSet<string>(_validationResults.SelectMany(x => x.MemberNames));
            foreach (var error in errors)
            {
                RaiseErrorsChanged(error);
            }
        }

        private void Validate(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == null)
                return;
            
            var propVal = GetPropertyValue(e.PropertyName);
            if(propVal == null)
                return;

            ClearErrorsForProperty(e.PropertyName);
            var context = new ValidationContext(_target) { MemberName = e.PropertyName };
            Validator.TryValidateProperty(propVal, context, _validationResults);
            var errors = new HashSet<string>(_validationResults.SelectMany(x => x.MemberNames));
            foreach (var error in errors)
            {
                RaiseErrorsChanged(error);
            }
        }

        private void ClearErrors()
        {
            _validationResults.Clear();
        }

        private void ClearErrorsForProperty(string propertyName)
        {
            _validationResults.RemoveAll(v => v.MemberNames.Contains(propertyName));
        }

        private object GetPropertyValue(string propertyName)
        {
            var propertyInfo = _target.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
                return null;

            if (propertyInfo.CanWrite == false)
                return null;

            var propVal = propertyInfo.GetValue(_target);

            return propVal;
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
