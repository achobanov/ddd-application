using System.Reflection;
using AutoMapper;
using Blog.Application.Infrastructure.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
    }
}
