using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Web.Controllers
{
    public class HomeController : BaseViewController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
