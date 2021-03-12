using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using EnduranceJudge.Core.ConventionalServices;

namespace EnduranceJudge.Core.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConventionalServices(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var serviceInterfaceType = typeof(IService);
            var singletonServiceInterfaceType = typeof(ISingletonService);
            var scopedServiceInterfaceType = typeof(IScopedService);

            var exportedClasses = assemblies
                .SelectMany(x => x.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract);

            var registrationDescriptors = exportedClasses
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                });

            var conventionalServices = registrationDescriptors.Where(t => t.Service != null);

            foreach (var service in conventionalServices)
            {
                if (serviceInterfaceType.IsAssignableFrom(service.Service))
                {
                    services.AddTransient(service.Service, service.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(service.Service))
                {
                    services.AddSingleton(service.Service, service.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(service.Service))
                {
                    services.AddScoped(service.Service, service.Implementation);
                }
            }

            return services;
        }
    }
}
