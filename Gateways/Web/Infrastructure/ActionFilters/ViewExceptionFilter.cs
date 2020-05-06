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
    public class ViewExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var model = new ErrorModel("This is broken!");
            var result = new ViewResult
            {
                ViewName = "Error",
            };
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };
            result.ViewData = viewData;

            context.Result = result;

            base.OnException(context);
        }
    }
}
