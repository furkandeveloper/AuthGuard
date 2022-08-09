using AuthGuard.Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AuthGuard.Application;

public static class Program
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeApplicationService, IEmployeeApplicationService>();
    }
}