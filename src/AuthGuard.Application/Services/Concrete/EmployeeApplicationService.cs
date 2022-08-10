using AuthGuard.Application.Dtos;
using AuthGuard.Application.Services.Abstractions;
using AuthGuard.Domain;
using AuthGuard.Infrastructure.Exceptions.Core.BadRequestExceptions;
using AutoMapper;
using EasyCache.Core.Abstractions;
using EasyCache.Core.Extensions;
using EasyRepository.EFCore.Generic;

namespace AuthGuard.Application.Services.Concrete;

public class EmployeeApplicationService : BaseService, IEmployeeApplicationService
{
    private readonly IMapper _mapper;
    private readonly IEasyCacheService _cache;
    private readonly string _name = "employee-";

    public EmployeeApplicationService(IUnitOfWork unitOfWork, IMapper mapper, IEasyCacheService cache) : base(unitOfWork)
    {
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto)
    {
        var entity = new Employee(dto.FirstName, dto.LastName, dto.Age);
        var response = await UnitOfWork.Repository.AddAsync<Employee, Guid>(entity);
        await UnitOfWork.Repository.CompleteAsync();
        var result = _mapper.Map<EmployeeResponseDto>(response);
        await _cache.SetAsync(_name + response.Id, result, TimeSpan.FromMinutes(5));
        return result;
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
        await _cache.RemoveAsync<EmployeeResponseDto>(_name + entity.Id);
        var result = _mapper.Map<EmployeeResponseDto>(response);
        await _cache.SetAsync(_name + response.Id, result, TimeSpan.FromMinutes(5));
        return result;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity =
            await UnitOfWork.Repository.GetSingleAsync<Employee>(asNoTracking: true,
                whereExpression: a => a.Id == id)
            ?? throw new EntityNotFoundException(nameof(Employee), instance: id.ToString());

        await UnitOfWork.Repository.HardDeleteAsync<Employee, Guid>(entity);
        await _cache.RemoveAsync<EmployeeResponseDto>(_name + entity.Id);
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

    public Task<EmployeeResponseDto> FindAsync(Guid id)
    {
        var result = _cache.GetAndSet(_name + id, () => GetById(id), TimeSpan.FromMinutes(5));
        return Task.FromResult(result);
    }
    private EmployeeResponseDto GetById(Guid id)
    {
        var entity =
            UnitOfWork.Repository.GetSingle<Employee>(asNoTracking: true,
                whereExpression: a => a.Id == id)
            ?? throw new EntityNotFoundException(nameof(Employee), instance: id.ToString());
        return _mapper.Map<EmployeeResponseDto>(entity);
    }
}