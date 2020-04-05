namespace Blog.Web.IntegrationTests
{
    using Blog.Application.Contracts;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyTested.AspNetCore.Mvc;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services
                .ReplaceTransient<IIdentityContext>(_ => Mocks.IdentityContext)
                .ReplaceTransient<IDateTime>(_ => Mocks.DateTime);
        }
    }
}
