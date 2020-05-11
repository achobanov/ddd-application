using Blog.Gateways.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters
{
    public class BaseViewExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                ViewResult result;
                ViewDataDictionary viewData;
                var model = new ErrorModel("This is broken!");

                result = new ViewResult
                {
                    ViewName = "Error",
                };

                viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                result.ViewData = viewData;
                context.Result = result;
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
