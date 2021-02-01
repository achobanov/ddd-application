using EnduranceContestManager.Core.Mappings;
using System.Reflection;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public class PersistenceMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => PersistenceCoreConstants.Assemblies;
    }
}
