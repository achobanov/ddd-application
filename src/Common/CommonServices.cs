using AutoMapper;
using EnduranceContestManager.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace EnduranceContestManager.Common
{
    public static class CommonServices
    {
        public static IServiceCollection AddCommon(this IServiceCollection services, params Assembly[] assemblies)
            => services
                .AddConventionalServices(assemblies)
                .AddMapping(assemblies);

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(assemblies);
    }
}
