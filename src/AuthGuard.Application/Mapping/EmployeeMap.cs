using AuthGuard.Application.Dtos;
using AuthGuard.Domain;
using AutoMapper;

namespace AuthGuard.Application.Mapping;

public class EmployeeMap : Profile
{
    public EmployeeMap()
    {
        CreateMap<Employee, EmployeeResponseDto>();
    }
}