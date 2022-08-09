using AuthGuard.Application.Services.Abstractions;
using EasyRepository.EFCore.Generic;

namespace AuthGuard.Application.Services.Concrete;

public class EmployeeApplicationService : BaseService, IEmployeeApplicationService
{
    public EmployeeApplicationService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }
}