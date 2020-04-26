using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Gateways.Persistence
{
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

            var user = await data.Users.FirstAsync();
            var author = new Author(user.Email, user.Id);
            var article = (new Article("Test Article", "Test Article Content", user.Id)
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now,
                Author = author
            });

            data.Authors.Add(author);
            data.Articles.Add(article);

            await data.SaveChangesAsync();
        }
    }
}
