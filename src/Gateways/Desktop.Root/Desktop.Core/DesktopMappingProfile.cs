using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Gateways.Desktop.Core
{
    public class DesktopMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => DesktopConstants.Assemblies;
    }
}