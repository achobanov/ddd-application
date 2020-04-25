using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Api
{
        [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator 
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();
    }
}
