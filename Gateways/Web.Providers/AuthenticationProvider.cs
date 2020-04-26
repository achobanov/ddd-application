using Microsoft.Extensions.DependencyInjection;
using Blog.Common.ConventionalServices;
using Blog.Authentication.Providers;

namespace Blog.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddTransient<Contracts.IAuthenticationContract, IdentityService>()
                .AddScoped<Application.Contracts.IAuthenticationContract, IdentityContext>();
    }
}
