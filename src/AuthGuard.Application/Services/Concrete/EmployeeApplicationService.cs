using AuthGuard.Application.Dtos;
using AuthGuard.Application.Services.Abstractions;
using AuthGuard.Domain;
using AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions;
using AutoMapper;
using EasyRepository.EFCore.Generic;

namespace AuthGuard.Application.Services.Concrete;

public class EmployeeApplicationService : BaseService, IEmployeeApplicationService
{
    private readonly IMapper _mapper;

    public EmployeeApplicationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto)
    {
        var entity = new Employee(dto.FirstName, dto.LastName, dto.Age);
        var response = await UnitOfWork.Repository.AddAsync<Employee, Guid>(entity);
        await UnitOfWork.Repository.CompleteAsync();
        return _mapper.Map<EmployeeResponseDto>(response);
    }

    public async Task<EmployeeResponseDto> UpdateAsync(Guid id, EmployeeRequestDto dto)
    {
        var entity =
            await UnitOfWork.Repository.GetSingleAsync<Employee>(asNoTracking: true,
                whereExpression: a => a.Id == id)
            ?? throw new EntityNotFoundException(nameof(Employee), instance: id.ToString());

        entity.Update(dto.FirstName, dto.LastName, dto.Age);
        var response = await UnitOfWork.Repository.UpdateAsync<Employee, Guid>(entity);
        await UnitOfWork.Repository.CompleteAsync();
        return _mapper.Map<EmployeeResponseDto>(response);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity =
            await UnitOfWork.Repository.GetSingleAsync<Employee>(asNoTracking: true,
                whereExpression: a => a.Id == id)
            ?? throw new EntityNotFoundException(nameof(Employee), instance: id.ToString());

        await UnitOfWork.Repository.HardDeleteAsync<Employee, Guid>(entity);
        await UnitOfWork.Repository.CompleteAsync();
    }

    public async Task<List<EmployeeResponseDto>> FilterAsync(EmployeeFilterDto dto)
    {
        var entities = await UnitOfWork.Repository.GetMultipleAsync<Employee, EmployeeFilterDto>(asNoTracking: false, dto);
        return _mapper.Map<List<EmployeeResponseDto>>(entities);
    }

    public async Task<int> CountAsync()
    {
        return await UnitOfWork.Repository.CountAsync<Employee>();
    }
}