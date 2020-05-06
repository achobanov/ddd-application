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
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ErrorModel error;

            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = 401;
                error = new ErrorModel("Unauthorized Access");
            } else
            {
                context.HttpContext.Response.StatusCode = 500;
                error = new ErrorModel();
            }

            context.Result = new JsonResult(error);

            base.OnException(context);
        }
    }
}
