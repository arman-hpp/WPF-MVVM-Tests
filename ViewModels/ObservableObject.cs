using WPF_MVVM_Tests.Models;

namespace WPF_MVVM_Tests.ViewModels
{
    public sealed class ObservableObject<TModel>(TModel model) where TModel : BaseEntity, new()
    {
        public TModel Properties { get; set; } = model;
    }
}
