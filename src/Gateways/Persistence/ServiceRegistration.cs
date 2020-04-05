namespace Blog.Gateways.Persistence
{
    using Application;
    using Blog.Application.Contracts;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
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
                .AddScoped<IBlogData>(provider => provider.GetService<BlogDbContext>());

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<IdentityUser, BlogDbContext>();

            return services;
        }
    }
}
