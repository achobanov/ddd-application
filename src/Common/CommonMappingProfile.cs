using System.Reflection;
using Blog.Common.Mappings;

namespace Blog.Common
{
    public class CommonMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
