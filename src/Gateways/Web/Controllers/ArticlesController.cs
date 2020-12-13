using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Gateways.Web.Infrastructure.Controllers;
using Blog.Application.Articles.Queries;

namespace Blog.Gateways.Web.Controllers
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