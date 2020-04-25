using System.Threading.Tasks;
using Blog.Application.Articles.Commands.ChangeVisibility;
using Blog.Application.Articles.Commands.Create;
using Blog.Application.Articles.Queries.Details;
using Blog.Application.Articles.Queries.IsByUser;
using Blog.Gateways.Web.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Gateways.Web.Api
{
    public class ArticlesController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailsModel>> Details(
            [FromRoute] ArticleDetailsQuery query)
            => await this.Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArticleCommand command)
            => await this.Mediator.Send(command);

        [HttpPut("[action]")]
        public async Task<ActionResult> ChangeVisibility(ChangeArticleVisibilityCommand command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<bool>> IsByUser(
            [FromRoute] ArticleIsByUserQuery query)
            => await this.Mediator.Send(query);
    }
}
