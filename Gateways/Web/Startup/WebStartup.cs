using Blog.Application;
using Blog.Application.Contracts;
using Blog.Gateways.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Gateways.Web.Providers;
using Blog.Common;
using Blog.Domain;

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
                .AddApplication()
                .AddInfrastructure(
                    typeof(WebMappingProfile).Assembly,
                    typeof(ApplicationMappingProfile).Assembly,
                    typeof(DomainMappingProfile).Assembly,
                    typeof(CommonMappingProfile).Assembly)
                .AddPersistence(this.Configuration)
                .AddAuthentication<BlogDbContext>(this.Configuration)
                .AddWebComponents();

            services
                .AddHealthChecks()
                .AddDbContextCheck<BlogDbContext>();

            services
                .AddControllers()
                .AddFluentValidation(options => options // unnecessary
                    .RegisterValidatorsFromAssemblyContaining<IPersistenceContract>())
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
