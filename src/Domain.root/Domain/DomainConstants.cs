using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Domain
{
    public static class DomainConstants
    {
        public static class Gender
        {
            public const string Female = "F";
            public const string Male = "M";
        }

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
