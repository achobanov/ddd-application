using System.Reflection;
using EnduranceContestManager.Core.Mappings;

namespace EnduranceContestManager.Gateways.Web
{
    public class WebMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
