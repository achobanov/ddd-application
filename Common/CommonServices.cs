using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Blog.Common.ConventionalServices;

namespace Blog.Common
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            params Assembly[] assemblies)
            => services
                .AddConventionalServices(assemblies)
                .AddMapping(assemblies);

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(assemblies);
    }
}
