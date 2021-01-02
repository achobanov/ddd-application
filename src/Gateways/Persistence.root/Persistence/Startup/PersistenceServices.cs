using EnduranceContestManager.Application.Interfaces.Blog.Articles;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EnduranceContestManager.Gateways.Persistence.Startup
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDataProtection();

            return services
                .AddDatabase()
                .AddTransient<IBlogDbContext, EcmDbContext>()
                .AddRepositories()
                .AddSingleton<IInitializerInterface, PersistenceInitializer>();
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
            => services
                .AddDbContext<EcmDbContext>(options =>
                    options
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddTransient<IArticleCommands, ArticlesRepository>()
                .AddTransient<IArticleQueries, ArticlesRepository>();
    }
}
