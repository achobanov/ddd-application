﻿using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Personnel;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents
{
    public class EnduranceEventViewModel : RootFormBase<SaveEnduranceEvent, EnduranceEventForUpdateModel>,
        ICompetitionsShard<CompetitionDependantViewModel>
    {
        protected EnduranceEventViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
        }

        public DelegateCommand NavigateToCompetition { get; private set; }
        public DelegateCommand AddPersonnel { get; }

        public ObservableCollection<CountryListingModel> Countries { get; }
            = new (Enumerable.Empty<CountryListingModel>());

        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        private string populatedPlace;
        public string PopulatedPlace
        {
            get => this.populatedPlace;
            set => this.SetProperty(ref this.populatedPlace, value);
        }

        private string selectedCountryIsoCode;
        public Visibility CountryVisibility { get; private set; } = Visibility.Hidden;
        public string SelectedCountryIsoCode
        {
            get => this.selectedCountryIsoCode;
            set => this.SetProperty(ref this.selectedCountryIsoCode, value);
        }

        public List<PersonnelViewModel> Personnel { get; private set; } = new();
        public ObservableCollection<ListItemViewModel> PersonnelItems { get; } = new();

        public List<CompetitionDependantViewModel> Competitions { get; private set; } = new();
        public ObservableCollection<ListItemViewModel> CompetitionItems { get; } = new();

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (!this.Countries.Any())
            {
                this.LoadCountries();
            }
        }

        private async Task LoadCountries()
        {
            var countries = await this.Application
                .Execute(new GetCountriesListing())
                .ToList();

            this.CountryVisibility = Visibility.Visible;

            this.Countries.AddRange(countries);
        }

        protected override IRequest<EnduranceEventForUpdateModel> LoadCommand(int id)
        {
            return new GetEnduranceEvent
            {
                Id = id,
            };
        }

        protected override ListItemViewModel ToListItem(DelegateCommand command)
        {
            var listItem = new ListItemViewModel(this.Id, this.Name, command);
            return listItem;
        }
    }
}