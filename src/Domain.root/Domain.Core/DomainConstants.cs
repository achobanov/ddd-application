using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Domain.Core
{
    public static class DomainConstants
    {
        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities.GetConventionalProjectNames("Domain");
                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }
    }
}