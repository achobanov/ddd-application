using System.Reflection;
using EnduranceContestManager.Common.Mappings;

namespace EnduranceContestManager.Application
{
    public class ApplicationMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };  
    }
}
