namespace Blog.Infrastructure
{
    using Application;
    using Application.Common.Interfaces;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
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
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<IdentityUser, BlogDbContext>();

            services
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);

            // services
            //    .AddTransient<IDateTime, DateTimeService>()
            //    .AddTransient<IIdentity, IdentityService>();

            services
                .AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
