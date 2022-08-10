using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
