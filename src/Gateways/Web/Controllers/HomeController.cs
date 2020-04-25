using Blog.Application.Contracts;
using Blog.Gateways.Web.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Blog.Gateways.Web.Common.WebConstants;

namespace Blog.Gateways.Web.Controllers
{
    [Route("[action]")]
    public class HomeController : BaseViewController
    {
        private readonly IAuthenticationContext authenticationContext;

        public HomeController(IAuthenticationContext authenticationContext)
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
