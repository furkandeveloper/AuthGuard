using EasyRepository.EFCore.Generic;

namespace AuthGuard.Application.Services;

public abstract class BaseService
{
    private IUnitOfWork UnitOfWork { get; }

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }   
}