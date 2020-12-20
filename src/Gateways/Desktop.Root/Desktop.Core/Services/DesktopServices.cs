using EnduranceContestManager.Gateways.Desktop.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Desktop.Core.Services
{
    public static class DesktopServices
    {
        public static IServiceCollection AddDesktop(this IServiceCollection services)
            => services
                .AddSingleton<IInitializerInterface, DesktopInitializer>();
    }
}