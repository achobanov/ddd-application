namespace Blog.Gateways.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeController : BaseViewController
    {
        [HttpGet]
        public Task<ActionResult> Index() 
            => Task.FromResult<ActionResult>(this.View());
    }
}
