using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;
            string message;

            if (context.Exception is ValidationException)
            {
                message = context.Exception.Message;
            } else
            {
                message = "Something went wrong.";
            }

            response.WriteJsonAsync(new { error = new { message } });
        }
    }
}
