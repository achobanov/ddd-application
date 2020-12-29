using EnduranceContestManager.Application.Core;
using EnduranceContestManager.Core;
using EnduranceContestManager.Domain;
using EnduranceContestManager.Gateways.Desktop.Core.Services;
using EnduranceContestManager.Gateways.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;

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
                .Concat(PersistenceConstants.Assemblies)
                .Concat(DesktopConstants.Assemblies)
                .ToArray();

            return services
                .AddCore(assemblies)
                .AddApplication()
                .AddPersistence()
                .AddDesktop();
        }

        private static void Register(this DesktopContainerAdapter adapter, ServiceDescriptor service)
        {
            if (service.Lifetime == ServiceLifetime.Transient &&
                service.Lifetime == ServiceLifetime.Scoped)
            {
                RegisterTransient(adapter, service);
            }
            else
            {
                RegisterSingleton(adapter, service);
            }
        }

        private static void RegisterSingleton(DesktopContainerAdapter adapter, ServiceDescriptor service)
        {
            if (service.ImplementationInstance != null)
            {
                adapter.RegisterSingleton(service.ServiceType, service.ImplementationInstance);
            }
            else if (service.ImplementationFactory != null)
            {
                adapter.RegisterSingleton(service.ServiceType, service.ImplementationFactory);
            }
            else
            {
                adapter.RegisterSingleton(service.ServiceType, service.ImplementationType);
            }
        }

        private static void RegisterTransient(DesktopContainerAdapter adapter, ServiceDescriptor service)
        {
            if (service.ImplementationInstance != null)
            {
                adapter.Register(service.ServiceType, service.ImplementationInstance);
            }
            else if (service.ImplementationFactory != null)
            {
                adapter.Register(service.ServiceType, service.ImplementationFactory);
            }
            else
            {
                adapter.Register(service.ServiceType, service.ImplementationType);
            }
        }
    }
}