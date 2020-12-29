using System.Threading.Tasks;
using EnduranceContestManager.Application.Articles.Commands;
using EnduranceContestManager.Application.Articles.Queries;
using EnduranceContestManager.Application.Articles.Queries.Details;
using EnduranceContestManager.Gateways.Web.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnduranceContestManager.Gateways.Web.Areas.Api
{
    [Area("Api")]
    public class ArticlesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailsModel>> Details(
            [FromRoute] GetArticleDetails query)
            => await this.Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArticle command)
            => await this.Mediator.Send(command);

        [HttpPut("[action]")]
        public async Task<ActionResult> ChangeVisibility(ChangeArticleVisibility command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }
    }
}
