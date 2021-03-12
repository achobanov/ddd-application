using EnduranceJudge.Application.Core;
using EnduranceJudge.Application;
using EnduranceJudge.Core;
using EnduranceJudge.Domain;
using EnduranceJudge.Gateways.Persistence.Core;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System.Linq;

namespace EnduranceJudge.Gateways.Desktop.Core.DI
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assemblies = CoreConstants.Assemblies
                .Concat(DomainConstants.Assemblies)
                .Concat(ApplicationConstants.Assemblies)
                .Concat(PersistenceCoreConstants.Assemblies)
                .Concat(DesktopConstants.Assemblies)
                .ToArray();

            return services
                .AddCore(assemblies)
                .AddApplication();
            // .AddPersistence();
        }

        public static IServiceCollection AdaptToDesktop(
            this IServiceCollection services,
            IContainerRegistry desktopContainer)
        {
            var adapter = new DesktopContainerAdapter(desktopContainer);
            foreach (var serviceDescriptor in services)
            {
                adapter.Register(serviceDescriptor);
            }

            return services;
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
