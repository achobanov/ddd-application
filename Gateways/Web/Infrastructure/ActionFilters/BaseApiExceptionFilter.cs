using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Blog.Gateways.Web.Models;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters
{
    public class BaseApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.HttpContext.Response.StatusCode = 500;
                var error = new ErrorModel();
                context.Result = new JsonResult(error);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
