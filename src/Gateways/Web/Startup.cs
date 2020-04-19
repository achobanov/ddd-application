namespace Blog.Gateways.Web
{
    using Application;
    using Application.Contracts;
    using FluentValidation.AspNetCore;
    using Infrastructure;
    using Infrastructure.Persistence;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Blog.Gateways.Web.Providers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Authentication.Cookies;

    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddInfrastructure(this.Configuration)
                .AddAuthentication<BlogDbContext>(this.Configuration)
                .AddWebComponents();

            services
                .AddHealthChecks()
                .AddDbContextCheck<BlogDbContext>();

            services
                .AddControllers()
                .AddFluentValidation(options => options // unnecessary
                    .RegisterValidatorsFromAssemblyContaining<IBlogData>())
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
