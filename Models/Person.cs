using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

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

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed partial class EmailValidationAttribute : ValidationAttribute
    {
        public EmailValidationAttribute()
            : base(() => "The email is invalid")
        {
        }

        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            var regex = EmailRegex();
            var match = regex.Match(value.ToString() ?? string.Empty);
            return match.Success;
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex EmailRegex();
    }
}
