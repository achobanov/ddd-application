using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Controller]
    public abstract class BaseViewController : Controller
    {
        protected IMediator Mediator { get; }
    }
}
