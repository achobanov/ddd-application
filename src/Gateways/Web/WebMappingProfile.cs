using System.Reflection;
using Blog.Common.Mappings;

namespace Blog.Gateways.Web
{
    public class WebMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
