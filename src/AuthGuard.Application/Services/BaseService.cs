using EasyRepository.EFCore.Generic;

namespace AuthGuard.Application.Services;

public abstract class BaseService
{
    protected internal IUnitOfWork UnitOfWork { get; }

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }   
}