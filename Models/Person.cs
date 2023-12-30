using System.ComponentModel.DataAnnotations;

namespace WPF_MVVM_Tests.Models
{
    public class Person : BaseEntity
    {
        [MinLength(5)]
        public string FirstName { get; set; }

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
}
