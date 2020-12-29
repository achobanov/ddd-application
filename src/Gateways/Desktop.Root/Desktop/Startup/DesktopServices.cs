using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Desktop.Core.DI;
using EnduranceContestManager.Gateways.Desktop.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;

namespace EnduranceContestManager.Gateways.Desktop.Startup
{
    public static class DesktopServices
    {
        public static IContainerRegistry AddServices(this IContainerRegistry container)
        {
            new ServiceCollection()
                .AddApplicationServices()
                .AddDesktop()
                .AdaptToDesktop(container);

            return container;
        }

        private static IServiceCollection AddDesktop(this IServiceCollection services)
            => services
                .AddSingleton<IInitializerInterface, DesktopInitializer>();
    }
}