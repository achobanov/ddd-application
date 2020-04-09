namespace Blog.Gateways.Web.Services
{
    using System.Security.Claims;
    using Blog.Application.Contracts;
    using Microsoft.AspNetCore.Http;

    public class IdentityContext : IIdentityContext
    {
        public IdentityContext(IHttpContextAccessor httpContextAccessor) 
            => this.UserId = httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

        public string UserId { get; }
    }
}
