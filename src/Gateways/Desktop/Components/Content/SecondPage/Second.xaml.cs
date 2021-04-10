using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage
{
    public partial class Second : UserControl, IView
    {
        public string RegionName { get; } = Regions.Content;

        public Second()
        {
            InitializeComponent();
        }

    }
}
