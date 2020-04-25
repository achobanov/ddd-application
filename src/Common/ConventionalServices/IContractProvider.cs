using Microsoft.Extensions.DependencyInjection;

namespace Blog.Common.ConventionalServices
{
    public interface IContractProvider
    {
        IServiceCollection ProvideImplementations(IServiceCollection services);
    }
}
