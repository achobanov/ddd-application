using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters.Validation
{
    public class ViewValidationExceptionFilter : BaseViewExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is ValidationException)
            {
                ViewResult result;
                ViewDataDictionary viewData;
                var actionName = context.RouteData.Values["action"].ToString();
                var message = context.Exception.Message;
                //This is an antipattern. It makes discerning a class's dependencies harder.
                var tempDataFactory = context.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();

                result = new ViewResult
                {
                    ViewName = actionName
                };

                viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = context.ModelState
                };

                result.TempData = tempDataFactory.GetTempData(context.HttpContext);
                result.TempData.Add("error", message);
                result.ViewData = viewData;
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
