using EnduranceJudge.Core.Utilities;
using System.Reflection;

namespace EnduranceJudge.Gateways.Desktop
{
    public static class DesktopConstants
    {
        public static Assembly[] Assemblies
        {
            get
            {
                var assemblies = ReflectionUtilities.GetAssemblies("EnduranceJudge.Gateways.Desktop");
                return assemblies;
            }
        }

        public const string EntityIdParameter = "Id";
        public const string OperationModeParameter = "OperationMode";
        public const string PrismEventPublishMethodName = "Publish";
    }

    public static class Regions
    {
        public const string Navigation = "NavigationRegion";
        public const string SubNavigation = "SubNavigationRegion";
        public const string Content = "ContentRegion";
    }
}
