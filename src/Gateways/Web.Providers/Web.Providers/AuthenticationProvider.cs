using Blog.Gateways.Web.Authentication;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Blog.Common.ConventionalServices;

namespace Blog.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddTransient<Contracts.IAuthenticationContract, IdentityService>()
                .AddScoped<Application.Contracts.IAuthenticationContract, IdentityContext>();
    }

    public static class Extensions
    {
        public static IServiceCollection AddAuthentication<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext, IPersistedGrantDbContext
            => services
                .AddDefaultIdentityWithCookieScheme<TDbContext>()
                .AddJwtScheme(configuration);

        private static IServiceCollection AddDefaultIdentityWithCookieScheme<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext, IPersistedGrantDbContext
        {
            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<TDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            return services;
        }

        private static IServiceCollection AddJwtScheme(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication()
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options => options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Tighten options for production
                        ValidateAudience = false,
                        ValidateActor = false,
                        ValidateTokenReplay = false,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SymmetricKeyFactory.Create(configuration["Jwt:Key"]),
                        ValidIssuer = configuration["Jwt:Issuer"],
                    });

            return services;
        }
    }
}
