namespace AuthGuard.Application.Dtos;

public class EmployeeResponseDto : BaseResponseDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }
}