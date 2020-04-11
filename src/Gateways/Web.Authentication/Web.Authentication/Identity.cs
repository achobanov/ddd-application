﻿namespace Blog.Infrastructure.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    using Blog.Application.Common.Interfaces;
    using Blog.Application.Common.Models;
    using Blog.Web.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class Identity : IIdentity
    {
        private readonly UserManager<IdentityUser> userManager;

        public Identity(UserManager<IdentityUser> userManager) 
            => this.userManager = userManager;

        public async Task<string> GetUserName(string userId)
            => await this.userManager
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();
        
        public async Task<(Result Result, string UserId)> CreateUser(string userName, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await this.userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUser(string userId)
        {
            var user = this.userManager
                .Users
                .SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await this.DeleteUser(user);
            }

            return Result.Success;
        }

        public async Task<Result> DeleteUser(IdentityUser user)
        {
            var result = await this.userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
    }
}