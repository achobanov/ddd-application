using EnduranceContestManager.Core.Mappings;
using System.Reflection;

namespace EnduranceContestManager.Gateways.Desktop.Core
{
    public class DesktopMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}