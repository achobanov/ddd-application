namespace Blog.Gateways.Persistence
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class BlogDbContextSeed
    {
        public static async Task SeedAsync(
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

            var userId = await data.Users.Select(u => u.Id).FirstAsync();

            data.Articles.Add(new Article("Test Article", "Test Article Content", userId)
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now
            });

            await data.SaveChangesAsync();
        }
    }
}
