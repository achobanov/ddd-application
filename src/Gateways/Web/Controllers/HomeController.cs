using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : BaseViewController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
