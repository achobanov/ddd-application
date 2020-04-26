using System;
using System.Threading.Tasks;
using Blog.Gateways.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blog.Gateways.Web
{
    public static class Initializer
    {
        public static IWebHost Initialize(this IWebHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<BlogDbContext>();
                context.Database.Migrate();

                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                Task
                    .Run(async () =>
                    {
                        await BlogDbContextSeed.SeedAsync(context, userManager);
                    })
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database.");
            }

            return host;
        }
    }
}
