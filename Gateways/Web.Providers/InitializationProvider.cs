using Blog.Common.ConventionalServices;
using Blog.Gateways.Persistence;
using Blog.Gateways.Web.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Providers
{
    public class InitializationProvider : IContractProvider
    {
        public IServiceCollection ProvideImplementations(IServiceCollection services)
            => services
                .AddSingleton<IInitializtion, BlogDbContextSeed>();
    }
}
