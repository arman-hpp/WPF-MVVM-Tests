namespace WPF_MVVM_Tests.Models
{
    public sealed class ObservableEntity<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
    {
        public TEntity Properties { get; set; } = entity;
    }
}
