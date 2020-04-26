using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Blog.Common
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            params Assembly[] assemblies)
            => services.AddMapping(assemblies);

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            return services.AddAutoMapper(assemblies);
        }
    }
}
