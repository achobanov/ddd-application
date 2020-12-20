using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Core.ConventionalServices
{
    public interface IContractProvider
    {
        IServiceCollection ProvideImplementations(IServiceCollection services);
    }
}
