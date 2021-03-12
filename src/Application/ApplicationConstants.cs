using EnduranceJudge.Core.Utilities;
using System.Reflection;

namespace EnduranceJudge.Application
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
