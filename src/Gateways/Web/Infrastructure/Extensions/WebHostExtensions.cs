using System.Linq;
using System.Threading.Tasks;
using Blog.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Infrastructure.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task Initialize(this IWebHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;

            var initializations = webHost.Services.GetServices<IInitialization>();

            foreach (var initalization in initializations)
            {
                await initalization.Initialize(services);
            }
        }
    }
}
