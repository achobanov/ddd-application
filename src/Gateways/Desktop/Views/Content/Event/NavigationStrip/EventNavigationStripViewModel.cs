﻿using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Roots.Athletes.Listing;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Roots.EnduranceEvents.Listing;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.NavigationStrip
{
    public class EventNavigationStripViewModel : ViewModelBase
    {
        public EventNavigationStripViewModel(INavigationService navigation)
        {
            this.ChangeToEventsList = new DelegateCommand(navigation.ChangeTo<EnduranceEventListView>);
            this.ChangeToAthletesList = new DelegateCommand(navigation.ChangeTo<AthleteListView>);
        }

        public DelegateCommand ChangeToEventsList { get; }
        public DelegateCommand ChangeToAthletesList { get; }
    }
}
