using EnduranceContestManager.Application.Core;
using EnduranceContestManager.Core;
using EnduranceContestManager.Domain;
using EnduranceContestManager.Gateways.Desktop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Desktop.Core
{
    public static class DesktopStartup
    {
        public static void ConfigureServices(IServiceCollection services)
            => services
                .AddCore(
                    typeof(DesktopMappingProfile).Assembly,
                    typeof(ApplicationMappingProfile).Assembly,
                    typeof(DomainMappingProfile).Assembly,
                    typeof(CoreMappingProfile).Assembly)
                .AddApplication()
                .AddDesktop();
    }
}