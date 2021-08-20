﻿using System.Threading.Tasks;
using Blog.Gateways.Web.Areas.Authentication.Models;
using Blog.Gateways.Web.Infrastructure.Extensions;
using Blog.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Blog.Gateways.Web.Infrastructure.WebConstants;
using Blog.Gateways.Web.Infrastructure.Controllers;

namespace Blog.Gateways.Web.Areas.Authentication.Controllers
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
