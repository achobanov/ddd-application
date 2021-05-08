﻿using EnduranceJudge.Gateways.Desktop.Core;
using System.Windows.Controls;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents
{
    public partial class EnduranceEvent : UserControl, IView
    {
        public EnduranceEvent()
        {
            InitializeComponent();
        }

        public string RegionName { get; } = Regions.Content;
    }
}