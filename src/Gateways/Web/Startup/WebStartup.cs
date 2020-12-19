using EnduranceContestManager.Gateways.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EnduranceContestManager.Authentication;
using EnduranceContestManager.Application;
using EnduranceContestManager.Common;
using EnduranceContestManager.Domain;
using EnduranceContestManager.Gateways.Persistence.Providers;

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
                .AddCommon(
                    typeof(WebMappingProfile).Assembly,
                    typeof(ApplicationMappingProfile).Assembly,
                    typeof(DomainMappingProfile).Assembly,
                    typeof(CommonMappingProfile).Assembly)
                .AddApplication()
                .AddPersistence(this.Configuration)
                .AddWeb()
                .AddAuthentication<EnduranceContestManagerDbContext>(this.Configuration);

            services
                .AddHealthChecks()
                .AddDbContextCheck<EnduranceContestManagerDbContext>();

            services
                .AddControllers()
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options => // probably unnecessary 
            {
                options.SuppressModelStateInvalidFilter = true;
            });
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
