using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Common.ConventionalServices
{
    public interface IContractProvider
    {
        IServiceCollection ProvideImplementations(IServiceCollection services);
    }
}
