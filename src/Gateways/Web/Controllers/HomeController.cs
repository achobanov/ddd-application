namespace Blog.Gateways.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseViewController
    {
        [HttpGet]
        public ActionResult Index() 
            => this.View();
    }
}
