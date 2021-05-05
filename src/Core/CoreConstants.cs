using EnduranceJudge.Core.Utilities;
using System.Reflection;

namespace EnduranceJudge.Core
{
    public static class CoreConstants
    {
        public const char StringSplitChar = ';';

        public static Assembly[] Assemblies
        {
            get
            {
                var assemblies = ReflectionUtilities.GetAssemblies("EnduranceJudge.Core");
                return assemblies;
            }
        }
    }
}
