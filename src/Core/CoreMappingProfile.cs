using System.Reflection;
using EnduranceContestManager.Core.Mappings;

namespace EnduranceContestManager.Core
{
    public class CoreMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => CoreConstants.Assemblies;
    }
}
