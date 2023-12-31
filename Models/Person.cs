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


}
