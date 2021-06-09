using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Create
{
    public partial class CreateEnduranceEventView : UserControl, IView
    {
        public CreateEnduranceEventView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
