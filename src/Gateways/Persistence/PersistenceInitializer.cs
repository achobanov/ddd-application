using System;
using System.Linq;
using System.Threading.Tasks;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Domain.Authors;
using EnduranceContestManager.Gateways.Persistence.Providers;
using EnduranceContestManager.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class PersistenceInitializer : IInitializer
    {
        public async Task Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<EnduranceContestManagerDbContext>();
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            this.Migrate(dbContext);
            await this.SeedAsync(dbContext, userManager);
        }

        private void Migrate(EnduranceContestManagerDbContext dbContext)
            => dbContext.Database.Migrate();

        private async Task SeedAsync(
            EnduranceContestManagerDbContext data,
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
            var author = new Author(user.Email, user.Id);
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
