using Blog.Application;
using Blog.Gateways.Persistence;
using Blog.Gateways.Web.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Common;
using Blog.Domain;
using Blog.Gateways.Persistence.Providers;
using Blog.Authentication;

namespace Blog.Gateways.Web
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
                .AddAuthentication<BlogDbContext>(this.Configuration);

            services
                .AddHealthChecks()
                .AddDbContextCheck<BlogDbContext>();

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
                .UseStaticFiles()
                .UseHealthChecks("/health")
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
