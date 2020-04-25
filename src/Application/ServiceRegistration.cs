namespace Blog.Application
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Infrastructure.Behaviours;
    using Infrastructure.Services;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

        public static IServiceCollection AddConventionalServices(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var serviceInterfaceType = typeof(IService);
            var singletonServiceInterfaceType = typeof(ISingletonService);
            var scopedServiceInterfaceType = typeof(IScopedService);

            var types = assemblies
                .SelectMany(x => x.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name.Replace("Service", string.Empty)}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddContractProviders(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var contractProviderType = typeof(IContractProvider);

            var contractProviders = assemblies
                .SelectMany(assembly => assembly.GetExportedTypes())
                .Where(type => type.IsClass && !type.IsAbstract && contractProviderType.IsAssignableFrom(type))
                .Select(Activator.CreateInstance)
                .Cast<IContractProvider>();

            foreach (var provider in contractProviders)
            {
                provider.ProvideImplementations(services);
            }

            return services;
        }
    }
}
