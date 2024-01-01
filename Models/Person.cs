using System.ComponentModel.DataAnnotations;

namespace WPF_MVVM_Tests.Models
{
    public class Person : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [PasswordValidation]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Person()
        {
            
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //private string _firstName;
        //private string _lastName;

        //[Required]
        //[MinLength(2)]
        //[MaxLength(100)]
        //public string FirstName
        //{
        //    get => _firstName;
        //    set => SetProperty(ref _firstName, value, true);
        //}

        //[Required]
        //[MinLength(2)]
        //[MaxLength(100)]
        //public string LastName
        //{
        //    get => _lastName;
        //    set => SetProperty(ref _lastName, value, true);
        //}

        //public new void ClearErrors(string propertyName)
        //{
        //    base.ClearErrors(propertyName);
        //}

        //public bool TrySetFirstName(string value, out IReadOnlyCollection<ValidationResult> errors)
        //{
        //    return TrySetProperty(ref this._firstName, value, out errors, nameof(FirstName));
        //}

        //public bool TrySetLastName(string value, out IReadOnlyCollection<ValidationResult> errors)
        //{
        //    return TrySetProperty(ref this._lastName, value, out errors, nameof(LastName));
        //}
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public sealed class PasswordValidationAttribute : ValidationAttribute
    {
        public PasswordValidationAttribute()
            : base(() => "The current value is smaller than the other one")
        {
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    if(IsValid(value))
        //        return ValidationResult.Success;

        //    return new ValidationResult("The current value is smaller than the other one");
        //}

        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return false;
            }

            if (value.Equals("aaa"))
                return true;

            return false;
        }
    }
}
