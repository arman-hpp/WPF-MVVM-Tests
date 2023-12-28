using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    public class BaseViewModel<TModel> : ObservableRecipient
        where TModel : BaseEntity, new()
    {
        private TModel _model;

        public BaseViewModel()
        {
            _model = new TModel();
        }

        public BaseViewModel(TModel model)
        {
            Model = model;
        }

        public TModel Model
        {
            get => _model;
            set
            {
                if (value == _model) return;

                if (_model != null)
                {
                    _model.PropertyChanged -= ModelPropertyChanged;
                }

                _model = value;

                if (_model != null)
                {
                    _model.PropertyChanged += ModelPropertyChanged;
                }
            }
        }

        protected virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
