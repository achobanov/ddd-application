using System.Reflection;
using AutoMapper;
using Blog.Application.Infrastructure.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
    }
}
