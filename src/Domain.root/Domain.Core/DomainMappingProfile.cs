using System.Reflection;
using EnduranceContestManager.Core.Mappings;

namespace EnduranceContestManager.Domain.Core
{
    public class DomainMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => DomainCoreConstants.Assemblies;
    }
}
