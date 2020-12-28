using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Application.Core
{
    public static class ApplicationConstants
    {
        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities.GetConventionalProjectNames("Application");
                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }
    }
}