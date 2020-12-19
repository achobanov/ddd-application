using System.Threading.Tasks;
using EnduranceContestManager.Gateways.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants;
using EnduranceContestManager.Gateways.Web.Areas.Authentication.Models;
using EnduranceContestManager.Gateways.Web.Contracts;
using EnduranceContestManager.Gateways.Web.Infrastructure.Controllers;

namespace EnduranceContestManager.Gateways.Web.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    [Route("/Account/[action]")]
    public class AccountController : BaseViewController
    {
        private readonly IAuthenticationContract authentication;

        public AccountController(IAuthenticationContract authentication)
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

            this.Response.Headers.Add("authorization-token", result.Data);

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
