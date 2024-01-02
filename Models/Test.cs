using System.ComponentModel.DataAnnotations;

namespace WPF_MVVM_Tests.Models
{
    public class Test : BaseEntity
    {
        [Range(10, 100)]
        [GreaterThan(nameof(B))]
        public int A { get; set; }

        [Range(20, 80)]
        public int B { get; set; }
    }

    public sealed class GreaterThanAttribute : ValidationAttribute
    {
        public GreaterThanAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object
                instance = validationContext.ObjectInstance,
                otherValue = instance.GetType().GetProperty(PropertyName)?.GetValue(instance);

            return ((IComparable)value).CompareTo(otherValue) > 0 
                ? ValidationResult.Success 
                : new ValidationResult("The current value is smaller than the other one");
        }
    }
}
