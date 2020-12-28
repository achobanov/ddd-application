using System.Reflection;
using EnduranceContestManager.Core.Mappings;

namespace EnduranceContestManager.Domain
{
    public class DomainMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => DomainConstants.Assemblies;
    }
}
