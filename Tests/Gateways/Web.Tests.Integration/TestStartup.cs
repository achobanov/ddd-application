using Blog.Gateways.Web;
using Blog.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;
using Blog.Common.Contracts;

namespace Blog.Web.Tests.Integration
{
    public class TestStartup : WebStartup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services
                .ReplaceTransient<IAuthenticationContext>(_ => Mocks.IdentityContext)
                .ReplaceTransient<IDateTime>(_ => Mocks.DateTime);
        }
    }
}
