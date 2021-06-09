using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Update
{
    public partial class UpdateEnduranceEventView : UserControl, IView
    {
        public UpdateEnduranceEventView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
