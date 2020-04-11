using System.Threading.Tasks;
using Blog.Gateways.Web.Authentication.Models;
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
                result.Errors.ForEach(e => this.ModelState.AddModelError(string.Empty, e));
                
                return this.View(model);
            }

            return this.Redirect(model.ReturnUrl);
        }
    }
}
