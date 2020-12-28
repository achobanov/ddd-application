using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Core
{
    public static class CoreConstants
    {
        public const string ProjectNameTemplate = "EnduranceContestManager.{0}";
        public const string CoreProjectNameTemplate = "EnduranceContestManager.{0}.Core";

        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities.GetConventionalProjectNames("Core");
                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }
    }
}