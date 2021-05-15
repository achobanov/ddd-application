using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample
{
    public partial class PrintExampleView : UserControl, IView
    {
        public PrintExampleView()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}
