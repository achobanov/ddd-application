using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions.Create
{
    public partial class CreateCompetitionView : UserControl, IView
    {
        public CreateCompetitionView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
