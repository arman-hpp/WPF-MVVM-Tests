namespace WPF_MVVM_Tests.ViewModels
{
    public abstract class BaseViewModel
    {

    }

    //public class BaseViewModel<TModel> : ObservableRecipient
    //    where TModel : BaseEntity, new()
    //{
    //    private TModel _model;

    //    public BaseViewModel()
    //    {
    //        _model = new TModel();
    //    }

    //    public BaseViewModel(TModel model)
    //    {
    //        Model = model;
    //    }

    //    public TModel Model
    //    {
    //        get => _model;
    //        set
    //        {
    //            if (value == _model) return;

    //            if (_model != null)
    //            {
    //                _model.PropertyChanged -= ModelPropertyChanged;
    //            }

    //            _model = value;

    //            if (_model != null)
    //            {
    //                _model.PropertyChanged += ModelPropertyChanged;
    //            }
    //        }
    //    }

    //    protected virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //    }
    //}

    //public class ObservableObject<TProperties> : ObservableRecipient
    //    where TProperties : BaseEntity, new()
    //{
    //    private TProperties _properties;

    //    public ObservableObject()
    //    {
    //        _properties = new TProperties();
    //    }

    //    public ObservableObject(TProperties model)
    //    {
    //        Properties = model;
    //    }

    //    public TProperties Properties
    //    {
    //        get => _properties;
    //        set
    //        {
    //            if (value == _properties) return;

    //            if (_properties != null)
    //            {
    //                _properties.PropertyChanged -= ObjectPropertyChanged;
    //            }

    //            _properties = value;

    //            if (_properties != null)
    //            {
    //                _properties.PropertyChanged += ObjectPropertyChanged;
    //            }
    //        }
    //    }

    //    protected virtual void ObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
            
    //    }
    //}

    //public class ObservableObject<TModel>(TModel model) where TModel : BaseEntity, new()
    //{
    //    //private TModel _properties;

    //    public TModel Properties { get; set; } = model;

    //    //public TModel Properties
    //    //{
    //    //    get => _properties;
    //    //    set
    //    //{
    //    //  if (value.Equals(_properties)) return;

    //    //   if (EqualityComparer<object>.Default.Equals(value, _properties)) return;

    //    //if (_properties != null)
    //    //{
    //    //    _properties.PropertyChanged -= ObjectPropertyChanged;
    //    //    _properties.ErrorsChanged -= ObjectErrorsChanged;
    //    //}

    //    //_properties = value;

    //    //if (_properties != null)
    //    //{
    //    //    _properties.PropertyChanged += ObjectPropertyChanged;
    //    //    _properties.ErrorsChanged += ObjectErrorsChanged;
    //    //}
    //    //}
    //    // }

    //    //private void ObjectErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    //    //{

    //    //}

    //    //protected virtual void ObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
    //    //{

    //    //}
    //}

    //public class Test : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
    //        field = value;
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }
    //}
}
