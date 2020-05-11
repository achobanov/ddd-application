using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Blog.Gateways.Web.Infrastructure.ActionFilters.Validation;

namespace Blog.Gateways.Web.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiValidationExceptionFilter]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator 
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();
    }
}
