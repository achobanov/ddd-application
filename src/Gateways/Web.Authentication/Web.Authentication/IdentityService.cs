using System.Threading.Tasks;
using Blog.Application.Common.Models;
using Blog.Gateways.Web.Contracts;
using Blog.Web.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Blog.Gateways.Web.Authentication
{
    public class IdentityService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityService(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public Task<Result> ChangePassword()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Result> Login(ILoginModelContract model)
        {
            var result = await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            return result.ToApplicationResult();
        }

        public Task<Result> Logout()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Result> Register(IRegisterModelContract model)
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
