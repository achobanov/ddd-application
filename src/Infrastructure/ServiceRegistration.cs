namespace Blog.Infrastructure
{
    using Application;
    using Blog.Application.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services
                .AddDbContext<BlogDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"), 
                        b => b.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName)))
                .AddScoped<IBlogData>(provider => provider.GetService<BlogDbContext>());

            services
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}
