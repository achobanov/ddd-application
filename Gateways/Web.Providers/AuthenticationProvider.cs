using Microsoft.Extensions.DependencyInjection;
using Blog.Common.ConventionalServices;
using Blog.Authentication.Providers;
using Blog.Gateways.Web.Contracts;
using Blog.Application.Contracts;

namespace Blog.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddTransient<IAuthenticationContract, IdentityService>()
                .AddScoped<IAuthenticationContext, IdentityContext>();
    }
}
