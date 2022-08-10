using AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions;
using EasyRepository.EFCore.Abstractions;

namespace AuthGuard.Domain
{
    /// <summary>
    /// Employee Entity
    /// </summary>
    [Serializable]
    public class Employee : EasyBaseEntity<Guid>
    {
        public Employee()
        {
            throw new NotConfiguredException();
        }
        public Employee(string firstName, string lastName, int age)
        {
            ArgumentNullException.ThrowIfNull(firstName);
            ArgumentNullException.ThrowIfNull(lastName);
            ArgumentNullException.ThrowIfNull(age);
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Update(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }
    }
}
