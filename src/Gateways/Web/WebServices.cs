using System;
using System.Linq;
using System.Reflection;
using Blog.Common.ConventionalServices;
using Blog.Gateways.Web.Contracts;
using Blog.Gateways.Web.Providers;
using Blog.Gateways.Web.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web
{
    public static class WebServices
    {
        public static IServiceCollection AddWeb(
            this IServiceCollection services)
            => services
                .AddHttpContextAccessor()
                .AddSingleton<IInitialization, WebInitialization>()
                .AddContractProviders(typeof(AuthenticationProvider).Assembly);

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
