using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace EnduranceJudge.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assemblies)
            => services
                .AddConventionalServices(assemblies)
                .AddMapping(assemblies)
                .AddSingleton<IInitializerInterface, CoreInitializer>();

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(
                configuration => configuration.AddCollectionMappers(),
                assemblies);
    }
}
