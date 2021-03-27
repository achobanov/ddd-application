using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Application.Interfaces.Countries;
using EnduranceJudge.Application.Interfaces.Events;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Repositories.Countries;
using EnduranceJudge.Gateways.Persistence.Repositories.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnduranceJudge.Gateways.Persistence.Startup
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            services.AddDataProtection();

            return services
                .AddDatabase()
                .AddTransient<IEventsDataStore, EnduranceJudgeDbContext>()
                .AddMapping(assemblies)
                .AddRepositories()
                .AddSingleton<IInitializerInterface, PersistenceInitializer>();
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
            => services
                .AddDbContext<EnduranceJudgeDbContext>();

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddTransient<IEventCommands, EventsRepository>()
                .AddTransient<IEventQueries, EventsRepository>()
                .AddTransient<ICountryQueries, CountryRepository>();

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(
                configuration =>
                {
                    configuration.AddCollectionMappers();
                    configuration.UseEntityFrameworkCoreModel<EnduranceJudgeDbContext>();
                    // configuration.SetGeneratePropertyMaps<
                    //     GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<EnduranceJudgeDbContext>>();
                },
                assemblies);
    }
}
