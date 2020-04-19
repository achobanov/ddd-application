using System.Text;
using Blog.Application.Common.Services;
using Blog.Application.Contracts;
using Blog.Gateways.Web.Authentication;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddTransient<Contracts.IAuthenticationService, IdentityService>()
                .AddScoped<IAuthenticationContext, IdentityContext>();
    }

    public static class Extensions
    {
        public static IServiceCollection AddAuthentication<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext, IPersistedGrantDbContext
            => services
                .AddCookieScheme<TDbContext>()
                .AddJwtScheme(configuration);

        private static IServiceCollection AddCookieScheme<TDbContext>(this IServiceCollection services)
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
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    });

            return services;
        }
    }
}
