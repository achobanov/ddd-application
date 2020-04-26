using Blog.Application.Contracts;
using Blog.Gateways.Web.Infrastructure.Controllers;
using Blog.Gateways.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Blog.Gateways.Web.Infrastructure.WebConstants;

namespace Blog.Gateways.Web.Controllers
{
    [Route("[action]")]
    public class HomeController : BaseViewController
    {
        private readonly IAuthenticationContract authenticationContext;

        public HomeController(IAuthenticationContract authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        [HttpGet]
        [Route(RootPath)]
        public Task<ActionResult> Index()
            => this
                .View()
                .AsTask();

        [Authorize]
        public Task<ActionResult> Authorized()
        {
            this.ViewBag.UserId = this.authenticationContext.Username;
            return this
                .View()
                .AsTask();
        }
    }
}
