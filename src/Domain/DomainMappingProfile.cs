using System.Reflection;
using EnduranceContestManager.Common.Mappings;

namespace EnduranceContestManager.Domain
{
    public class DomainMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
