using EnduranceJudge.Core.Utilities;
using System.Reflection;

namespace EnduranceJudge.Core
{
    public static class CoreConstants
    {
        public const string ProjectNameTemplate = "EnduranceJudge.{0}";

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
