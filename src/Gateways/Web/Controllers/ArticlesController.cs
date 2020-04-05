namespace Blog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Blog.Application.Articles.Queries.Details;
    public class ArticlesController : BaseViewController
    {
        [HttpGet("{id}")]
        async public Task<ActionResult> Index([FromRoute] ArticleDetailsQuery query)
        {
            var articleDetails = await Mediator.Send(query);
            
            return View(articleDetails);
        }
    }
}