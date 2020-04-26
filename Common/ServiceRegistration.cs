using Blog.Common.ConventionalServices;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Common
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddConventionalServices(typeof(ServiceRegistration).Assembly);
    }
}
