using System.Reflection;
using Blog.Common.Mappings;

namespace Blog.Application
{
    public class ApplicationMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
