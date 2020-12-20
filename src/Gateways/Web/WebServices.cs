using System;
using System.Linq;
using System.Reflection;
using EnduranceContestManager.Common.ConventionalServices;
using EnduranceContestManager.Gateways.Web.Contracts;
using EnduranceContestManager.Gateways.Web.Providers;
using EnduranceContestManager.Gateways.Web.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Web
{
    public static class WebServices
    {
        public static IServiceCollection AddWeb(
            this IServiceCollection services)
            => services
                .AddHttpContextAccessor()
                .AddSingleton<IInitializer, WebInitializer>()
                .AddContractProviders(typeof(PersistenceProvider).Assembly);

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
