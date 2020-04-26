using Blog.Common.ConventionalServices;
using Blog.Gateways.Web.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web
{
    public static class WebServices
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
            => services
                .AddHttpContextAccessor()
                .AddContractProviders(typeof(AuthenticationProvider).Assembly);
    }
}
