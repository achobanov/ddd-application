namespace Blog.Web.Controllers
{
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
    }
}
