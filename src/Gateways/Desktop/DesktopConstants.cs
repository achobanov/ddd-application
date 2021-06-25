using EnduranceJudge.Core.Utilities;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
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
        public const string PrismEventPublishMethodName = "Publish";
        public const string DataParameter = "Data";
        public const string SubmitActionParameter = "SubmitAction";

        public static class Types
        {
            public static readonly Type DelegateCommand = typeof(DelegateCommand);
            public static readonly Type ObservableListItems = typeof(ObservableCollection<ListItemViewModel>);
            public static readonly Type ListItemViewModel = typeof(ListItemViewModel);
            public static readonly Type PrincipalForm = typeof(IPrincipalForm);
            public static readonly Type HasView = typeof(IHasView<>);
        }
    }

    public static class Regions
    {
        public const string Navigation = "NavigationRegion";
        public const string SubNavigation = "SubNavigationRegion";
        public const string Content = "ContentRegion";
    }
}
