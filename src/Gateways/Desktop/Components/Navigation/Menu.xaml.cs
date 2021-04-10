using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public partial class Menu : UserControl, IView
    {
        public string RegionName { get; } = Regions.Navigation;

        public Menu()
        {
            InitializeComponent();
        }

    }
}
