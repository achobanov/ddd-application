using System.Reflection;
using EnduranceContestManager.Application.Core.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
    }
}
