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
        public Employee(string firstName, string lastName, int age)
        {
            ArgumentNullException.ThrowIfNull(firstName);
            ArgumentNullException.ThrowIfNull(lastName);
            if (age < 0)
                throw new ArgumentException(nameof(age));
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Update(string firstName, string lastName, int age)
        {
            ArgumentNullException.ThrowIfNull(firstName);
            ArgumentNullException.ThrowIfNull(lastName);
            FirstName = firstName;
            LastName = lastName;
            if (age < 0)
                throw new ArgumentException(nameof(age));
            Age = age;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }
    }
}
