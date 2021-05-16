using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions.List
{
    public partial class CompetitionListView : UserControl, IView
    {
        public CompetitionListView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
