using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CleanArchitectureV2._0.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureV2._0.Application.Repositories;
using CleanArchitectureV2._0.Persistence.Repositories;

namespace CleanArchitectureV2._0.Persistence
{
    public static class ServiceExtension
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TestCleanArchitecture");
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("CleanArchitectureV2.0.Persistence")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
