using Microsoft.Extensions.DependencyInjection;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Authentication.Providers;
using EnduranceContestManager.Common.ConventionalServices;
using EnduranceContestManager.Gateways.Web.Contracts;

namespace EnduranceContestManager.Gateways.Web.Providers
{
    public class AuthenticationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddTransient<IAuthenticationContract, IdentityService>()
                .AddScoped<IAuthenticationContext, IdentityContext>();
    }
}
