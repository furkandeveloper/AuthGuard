using Ardalis.Specification;

namespace AuthGuard.Domain
{
    public sealed class EmployeeActiveSpecification : Specification<Employee>
    {
        public EmployeeActiveSpecification()
        {
            Query.Where(a => !a.IsDeleted);
        }
    }
}
