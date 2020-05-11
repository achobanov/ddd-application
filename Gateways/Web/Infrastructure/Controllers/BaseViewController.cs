using System;
using Blog.Common.Extensions;
using Blog.Common.Models;
using Blog.Gateways.Web.Infrastructure.ActionFilters.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Infrastructure.Controllers
{
    [Controller]
    [Route("[controller]")]
    [ViewValidationExceptionFilter]
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
