using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Behaviours;

namespace TodoList.Application.Extensions
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
