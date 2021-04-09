using EnduranceJudge.Core.Utilities;
using System.Reflection;

namespace EnduranceJudge.Gateways.Desktop
{
    public static class DesktopConstants
    {
        public static string Test = "testvalue";

        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities.GetConventionalProjectNames("Desktop");
                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }
    }

    public static class Regions
    {
        public const string Navigation = "NavigationRegion";
        public const string Content = "ContentRegion";
    }
}
