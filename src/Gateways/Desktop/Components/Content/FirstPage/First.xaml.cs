using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage
{
    public partial class First : UserControl, IView
    {
        public string RegionName { get; } = Regions.Content;

        public First()
        {
            InitializeComponent();
        }

    }
}
