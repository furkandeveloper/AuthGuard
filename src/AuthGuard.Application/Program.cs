using AuthGuard.Application.Services.Abstractions;
using AuthGuard.Application.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace AuthGuard.Application;

public static class Program
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeApplicationService, EmployeeApplicationService>();
    }
}