namespace AuthGuard.Application.Dtos;

public class BaseResponseDto
{
    public Guid Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }
}