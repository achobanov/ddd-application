using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Blog.Gateways.Persistence.Providers;
using Blog.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Persistence
{
    public class PersistenceInitialization : IInitializtion
    {
        public async Task Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<BlogDbContext>();
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            this.Migrate(dbContext);
            await this.SeedAsync(dbContext, userManager);
        }

        private void Migrate(BlogDbContext dbContext)
            => dbContext.Database.Migrate();

        private async Task SeedAsync(
            BlogDbContext data,
            UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "admin@dev.com",
                Email = "admin@dev.com"
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "Test1!");
            }

            if (data.Articles.Any())
            {
                return;
            }

            var user = await data.Users.FirstAsync();
            var author = new Author(user.UserName);
            var article = new Article("Test Article", "Test Article Content")
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now,
                Author = author,
                CreatedBy = user.Id,
            };

            data.Authors.Add(author);
            data.Articles.Add(article);

            await data.SaveChangesAsync();
        }
    }
}
