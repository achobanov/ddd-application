using System.Reflection;
using Blog.Common.Mappings;

namespace Blog.Domain
{
    public class DomainMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
