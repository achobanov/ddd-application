using EnduranceContestManager.Gateways.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EnduranceContestManager.Application.Core;
using EnduranceContestManager.Core;
using EnduranceContestManager.Domain;

namespace EnduranceContestManager.Gateways.Web
{
    public class WebStartup
    {
        public WebStartup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCore(
                    typeof(WebMappingProfile).Assembly,
                    typeof(ApplicationMappingProfile).Assembly,
                    typeof(DomainMappingProfile).Assembly,
                    typeof(CoreMappingProfile).Assembly)
                .AddApplication()
                .AddPersistence(this.Configuration)
                .AddWeb();
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
                application.UseDatabaseErrorPage();
            }
            else
            {
                application.UseHsts();
            }

            application
                // app.UseCustomExceptionHandler();
                .UseHealthChecks("/health")
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
