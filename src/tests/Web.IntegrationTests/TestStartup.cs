using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Common.Contracts;
using EnduranceContestManager.Gateways.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;

namespace Blog.Web.IntegrationTests
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
