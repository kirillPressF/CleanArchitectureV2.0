
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureV2._0.Application.Common.Behaviors;
using MediatR;
using FluentValidation;

namespace CleanArchitectureV2._0.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(configure =>
            {
                configure.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
