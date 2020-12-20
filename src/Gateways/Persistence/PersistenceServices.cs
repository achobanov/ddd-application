using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddScoped<IPersistenceContract, ContestDbContext>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<ContestDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ContestDbContext).Assembly.FullName)));
    }
}
