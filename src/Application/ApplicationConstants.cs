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
                var assemblies = ReflectionUtilities.GetAssemblies("EnduranceJudge.Application");
                return assemblies;
            }
        }

        public const string WorkFileName = "endurance-judge-file";
    }
}
