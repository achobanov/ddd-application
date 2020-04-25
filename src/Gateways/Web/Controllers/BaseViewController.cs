namespace Blog.Gateways.Web.Controllers
{
    using System;
    using Blog.Application.Infrastructure.Models;
    using Blog.Gateways.Web.Infrastructure.Extensions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [Controller]
    [Route("[controller]")]
    public abstract class BaseViewController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();

        protected ViewResult FailureResult(object model, Result result)
        {
            if (result.Succeeded)
            {
                throw new ArgumentException($"Provided '{nameof(result)}' argument has no errors.");
            }

            result.Errors.ForEach(e => this.ModelState.AddModelError(string.Empty, e));

            return this.View(model);
        }
    }
}
