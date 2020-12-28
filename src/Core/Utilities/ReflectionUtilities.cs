using System.Linq;
using System.Reflection;

namespace EnduranceContestManager.Core.Utilities
{
    public static class ReflectionUtilities
    {
        public static Assembly[] GetAssemblies(params string[] projectNames)
        {
            var assemblies = projectNames
                .Select(name =>
                {
                    try
                    {
                        return Assembly.Load(name);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(assembly => assembly != null)
                .ToArray();

            return assemblies;
        }
    }
}