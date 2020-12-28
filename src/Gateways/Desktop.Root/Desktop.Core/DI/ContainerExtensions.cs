using EnduranceContestManager.Application.Core;
using EnduranceContestManager.Core;
using EnduranceContestManager.Domain;
using EnduranceContestManager.Gateways.Desktop.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System;
using System.Reflection;
using System.Linq;

namespace EnduranceContestManager.Gateways.Desktop.Core.DI
{
    public static class ContainerExtensions
    {
        public static IContainerRegistry AddServices(this IContainerRegistry container)
        {
            var adapter = new DesktopContainerAdapter(container);
            var services = new ServiceCollection().AddProjectServices();

            foreach (var serviceDescriptor in services)
            {
                adapter.Register(serviceDescriptor);
            }

            return container;
        }

        private static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            var assemblies = CoreConstants.Assemblies
                .Concat(DomainConstants.Assemblies)
                .Concat(ApplicationConstants.Assemblies)
                .Concat(DesktopConstants.Assemblies)
                .ToArray();

            return services
                .AddCore(assemblies)
                .AddApplication()
                .AddDesktop();
        }

        private static void Register(this DesktopContainerAdapter adapter, ServiceDescriptor service)
        {
            if (service.Lifetime != ServiceLifetime.Singleton &&
                service.Lifetime != ServiceLifetime.Transient)
            {
                throw new InvalidOperationException($"Unsupported service lifestyle: {service.Lifetime}");
            }
            
            if (service.ImplementationInstance != null)
            {
                if (service.Lifetime == ServiceLifetime.Singleton)
                {
                    adapter.RegisterSingleton(service.ServiceType, service.ImplementationInstance);
                }
                else
                {
                    adapter.Register(service.ServiceType, service.ImplementationInstance);
                }
            }
            else if (service.ImplementationFactory != null)
            {
                if (service.Lifetime == ServiceLifetime.Singleton)
                {
                    adapter.RegisterSingleton(service.ServiceType, service.ImplementationFactory);
                }
                else
                {
                    adapter.Register(service.ServiceType, service.ImplementationFactory);
                }
            }
            else
            {
                if (service.Lifetime == ServiceLifetime.Singleton)
                {
                    adapter.RegisterSingleton(service.ServiceType, service.ImplementationType);
                }
                else
                {
                    adapter.Register(service.ServiceType, service.ImplementationType);
                }
            }
        }
        
    }
}