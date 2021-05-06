using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample
{
    public partial class PrintExample : UserControl, IView
    {
        public PrintExample()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
