namespace Blog.Gateways.Web
{
    using Application;
    using Blog.Gateways.Web.Providers;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
            => services
                .AddHttpContextAccessor()
                .AddConventionalServices(typeof(ServiceRegistration).Assembly)
                .AddContractProviders(typeof(AuthenticationProvider).Assembly);
    }
}
