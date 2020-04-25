using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Common.Services
{
    public interface IContractProvider
    {
        IServiceCollection ProvideImplementations(IServiceCollection services);
    }
}
