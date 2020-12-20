using EnduranceContestManager.Gateways.Web.Infrastructure.Extensions;
using EnduranceContestManager.Gateways.Web.Infrastructure.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants;

namespace EnduranceContestManager.Gateways.Web.Controllers
{
    [Route("[action]")]
    public class HomeController : BaseViewController
    {
        [HttpGet]
        [Route(RootPath)]
        public Task<ActionResult> Index()
            => this
                .View()
                .AsTask();
    }
}
