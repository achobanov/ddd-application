using System.Threading.Tasks;
using Blog.Application.Articles.Commands;
using Blog.Application.Articles.Queries;
using Blog.Application.Articles.Queries.IsByUser;
using Blog.Gateways.Web.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Gateways.Web.Areas.Api
{
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

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<bool>> IsByUser([FromRoute] IsArticleByAuthor query)
            => await this.Mediator.Send(query);
    }
}
