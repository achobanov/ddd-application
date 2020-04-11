using System.Threading.Tasks;
using Blog.Gateways.Web.Areas.Authentication.Models;
using Blog.Gateways.Web.Common.Extensions;
using Blog.Gateways.Web.Contracts;
using Blog.Gateways.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using static Blog.Gateways.Web.Common.WebConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    [Route("/Account/[action]")]
    public class AccountController : BaseViewController
    {
        private readonly IAuthenticationService authentication;

        public AccountController(IAuthenticationService authentication)
            => this.authentication = authentication;

        [HttpGet]
        public Task<ActionResult> Register(string returnUrl = RootPath)
            => this
                .View(new RegisterViewModel { ReturnUrl = returnUrl })
                .AsTask();

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return await this
                    .View(model)
                    .AsTask();
            }

            var result = await this.authentication.Register(model);
            if (!result.Succeeded)
            {
                return this.FailureResult(model, result);
            }

            return this.Redirect(model.ReturnUrl);
        }

        [HttpGet]
        public Task<ActionResult> Login(string returnUrl = RootPath)
            => this
                .View(new LoginViewModel { ReturnUrl = returnUrl })
                .AsTask();

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return await this
                    .View(model)
                    .AsTask();
            }

            var result = await this.authentication.Login(model);
            if (!result.Succeeded)
            {
                return this.FailureResult(model, result);
            }

            return this.Redirect(model.ReturnUrl);
        }

        [HttpPost]
        public async Task<ActionResult> Logout(string returnUrl = RootPath)
        {
            await this.authentication.Logout();

            return this.Redirect(returnUrl);
        }
    }
}
