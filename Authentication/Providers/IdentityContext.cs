using Blog.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Gateways.Web.Authentication.Providers
{
    public class IdentityContext : IAuthenticationContract
    {
        private readonly HttpContext httpContext;
        
        public IdentityContext(IHttpContextAccessor httpContextAccessor)
            => this.httpContext = httpContextAccessor.HttpContext;

        public string Username => this.httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
