using System.Reflection;
using EnduranceContestManager.Common.Mappings;

namespace EnduranceContestManager.Common
{
    public class CommonMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
