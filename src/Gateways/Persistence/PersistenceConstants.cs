using EnduranceContestManager.Core.Utilities;
using System.Reflection;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class PersistenceConstants
    {
        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities.GetConventionalProjectNames("Persistence");
                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }
    }
}