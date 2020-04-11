namespace Blog.Web.Authentication
{
    using Blog.Infrastructure.Persistence;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddApiAuthentication(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<IdentityUser, BlogDbContext>();

            services
                .AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
