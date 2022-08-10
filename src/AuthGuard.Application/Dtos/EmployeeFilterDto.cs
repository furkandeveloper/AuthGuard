using AutoFilterer.Attributes;
using AutoFilterer.Types;

namespace AuthGuard.Application.Dtos;

[PossibleSortings("FirstName","LastName","Age","CreationDate")]
public class EmployeeFilterDto : PaginationFilterBase
{
    [ToLowerContainsComparison]
    public string FirstName { get; set; }
    
    [ToLowerContainsComparison]
    public string LastName { get; set; }
    
    public Range<int> Age { get; set; }

    public Range<DateTime> CreationDate { get; set; }
}