using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Import
{
    public partial class Import : UserControl, IView
    {
        public string RegionName { get; } = Regions.Content;

        public Import()
        {
            InitializeComponent();
        }
    }
}
