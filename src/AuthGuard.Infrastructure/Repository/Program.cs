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
        public static void ApplyRepository<TDbContext>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TDbContext : DbContext
        {
            services.ApplyRepository<TDbContext>(lifetime);
        }
    }
}
