using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public partial class CompetitionDependentView : UserControl, IView
    {
        public CompetitionDependentView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
