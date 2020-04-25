using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Articles.Queries.Details;

namespace Blog.Gateways.Web.Controllers
{
    public class ArticlesController : BaseViewController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> Index([FromRoute] ArticleDetailsQuery query)
        {
            var articleDetails = await Mediator.Send(query);
            
            return View(articleDetails);
        }
    }
}