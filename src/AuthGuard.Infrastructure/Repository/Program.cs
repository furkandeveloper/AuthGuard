using EasyRepository.EFCore.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthGuard.Infrastructure.Repository
{
    public static class Program
    {
        public static void ApplyGenericRepositoryPattern<TDbContext>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TDbContext : DbContext
        {
            services.ApplyEasyRepository<TDbContext>(lifetime);
        }
    }
}
