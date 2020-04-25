namespace Blog.Gateways.Persistence
{
    using Blog.Application.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services
                .AddDbContext<BlogDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"), 
                        b => b.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName)))
                .AddScoped<IPersistenceContract>(provider => provider.GetService<BlogDbContext>());

            return services;
        }
    }
}
