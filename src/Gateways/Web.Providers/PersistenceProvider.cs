using EnduranceContestManager.Core.ConventionalServices;
using EnduranceContestManager.Gateways.Persistence;
using EnduranceContestManager.Gateways.Web.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Web.Providers
{
    public class PersistenceProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddSingleton<IInitializer, PersistenceInitializer>();
    }
}
