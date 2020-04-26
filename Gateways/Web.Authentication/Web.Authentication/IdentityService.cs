using System;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Models;
using Blog.Gateways.Web.Contracts;
using Blog.Web.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Blog.Gateways.Web.Authentication
{
    public class IdentityService : IAuthenticationContract
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityService(
            IMapper mapper,
            IConfiguration configuration,
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result<string>> Login(ILoginModel model)
        {
            var result = await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Result<string>.Failure(result.ToString());
            }

            var jwtToken = JwtTokenFactory.Create(
                model.Username,
                configuration["Jwt:Key"],
                configuration["Jwt:Issuer"],
                TimeSpan.FromDays(int.Parse(configuration["Jwt:ExpirationInDays"])));

            return Result<string>.Success(jwtToken);
        }

        public Task Logout()
            => this.signInManager.SignOutAsync();

        public async Task<Result> Register(IRegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username };
            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return result.ToApplicationResult();
            }

            await this.signInManager.SignInAsync(user, isPersistent: false);

            return Result.Success;
        }
    }
}
