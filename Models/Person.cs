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
