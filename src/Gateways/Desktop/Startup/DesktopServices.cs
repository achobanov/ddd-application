using EnduranceJudge.Gateways.Desktop.Core.DI;
using EnduranceJudge.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;

namespace EnduranceJudge.Gateways.Desktop.Startup
{
    public static class DesktopServices
    {
        public static IContainerRegistry AddServices(this IContainerRegistry container)
        {
            new ServiceCollection()
                .AddApplicationServices()
                .AdaptToDesktop(container);

            return container;
        }
    }
}
