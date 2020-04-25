using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Infrastructure.Services
{
    public interface IContractProvider
    {
        IServiceCollection ProvideImplementations(IServiceCollection services);
    }
}
