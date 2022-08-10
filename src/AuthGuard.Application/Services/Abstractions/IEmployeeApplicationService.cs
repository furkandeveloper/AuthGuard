using AuthGuard.Application.Dtos;

namespace AuthGuard.Application.Services.Abstractions;

public interface IEmployeeApplicationService
{
    Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto);

    Task<EmployeeResponseDto> UpdateAsync(Guid id, EmployeeRequestDto dto);

    Task DeleteAsync(Guid id);

    Task<List<EmployeeResponseDto>> FilterAsync(EmployeeFilterDto dto);

    Task<int> CountAsync();
}