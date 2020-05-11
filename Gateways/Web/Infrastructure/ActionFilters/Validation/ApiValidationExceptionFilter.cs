using Blog.Gateways.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters.Validation
{
    public class ApiValidationExceptionFilter : BaseApiExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = 401;
                var error = new ErrorModel("Unauthorized Access");
                context.Result = new JsonResult(error);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
