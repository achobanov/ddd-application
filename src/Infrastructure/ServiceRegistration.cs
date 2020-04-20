namespace Blog.Infrastructure
{
    using Application;
    using Blog.Application.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}
