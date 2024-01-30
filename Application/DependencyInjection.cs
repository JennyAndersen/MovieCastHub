using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            
            AssemblyScanner.FindValidatorsInAssembly(assembly)
.Select(result => new ServiceDescriptor(result.InterfaceType, result.ValidatorType, ServiceLifetime.Transient))
.ToList()
.ForEach(descriptor => services.Add(descriptor));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services; 
        }
    }
}
