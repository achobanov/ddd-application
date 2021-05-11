using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents.List
{
    public partial class EnduranceEventList : UserControl, IView
    {
        public EnduranceEventList()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
