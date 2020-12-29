using EnduranceContestManager.Core.ConventionalServices;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Web.Providers
{
    public class PersistenceProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services;
    }
}
