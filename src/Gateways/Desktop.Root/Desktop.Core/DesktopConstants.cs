using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Gateways.Desktop.Core
{
    public static class DesktopConstants
    {
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
}