﻿using Blog.Application.Common.Services;
using Blog.Gateways.Web.Authentication;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services.AddTransient<Contracts.IAuthenticationService, IdentityService>();
    }

    public static class Extensions
    {
        public static IServiceCollection AddApiAuthentication<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext, IPersistedGrantDbContext
        {
            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<TDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<IdentityUser, TDbContext>();

            services
                .AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}