using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnduranceContestManager.Application.Articles.Queries;
using EnduranceContestManager.Application.Articles.Queries.Details;
using EnduranceContestManager.Gateways.Web.Infrastructure.Controllers;

namespace EnduranceContestManager.Gateways.Web.Controllers
{
    public class ArticlesController : BaseViewController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> Index([FromRoute] GetArticleDetails query)
        {
            var articleDetails = await Mediator.Send(query);

            return View(articleDetails);
        }
    }
}