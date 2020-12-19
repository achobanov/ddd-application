using System.Linq;
using System.Threading.Tasks;
using EnduranceContestManager.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Web.Infrastructure.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task Initialize(this IWebHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;

            var initializations = webHost.Services.GetServices<IInitializer>();

            foreach (var initialization in initializations)
            {
                await initialization.Initialize(services);
            }
        }
    }
}
