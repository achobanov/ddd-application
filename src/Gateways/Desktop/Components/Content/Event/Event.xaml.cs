using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event
{
    public partial class Event : UserControl, IView
    {
        public Event()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
