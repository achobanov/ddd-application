using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Infrastructure.Services
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new[]
            {
                "../Gateways/Web/Views/{1}/{0}.cshtml",
                "../Gateways/Web/Views/Shared/{0}.cshtml",
            };
        }

        public void PopulateValues(ViewLocationExpanderContext context) { }
    }
}
