using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public partial class CompetitionDependantView : UserControl, IView
    {
        public CompetitionDependantView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
