using EnduranceJudge.Core.ConventionalServices;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace EnduranceJudge.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCore(
            this IServiceCollection services,
            params Assembly[] assemblies)
            => services
                .AddConventionalServices(assemblies);

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

            var registrationDescriptors = exportedClasses.Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            });

            foreach (var descriptor in registrationDescriptors.Where(t => t.Service != null))
            {
                if (serviceInterfaceType.IsAssignableFrom(descriptor.Service))
                {
                    services.AddTransient(descriptor.Service!, descriptor.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(descriptor.Service))
                {
                    services.AddSingleton(descriptor.Service!, descriptor.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(descriptor.Service))
                {
                    services.AddScoped(descriptor.Service!, descriptor.Implementation);
                }
            }

            return services;
        }
    }
}
