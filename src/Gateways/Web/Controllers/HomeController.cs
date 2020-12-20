using EnduranceContestManager.Gateways.Web.Infrastructure.Extensions;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Gateways.Web.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants;

namespace EnduranceContestManager.Gateways.Web.Controllers
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
