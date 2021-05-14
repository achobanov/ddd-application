using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event.NavigationStrip
{
    public partial class EventNavigationStrip : UserControl, IView
    {
        public EventNavigationStrip()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.SubNavigation;
    }
}
