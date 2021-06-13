﻿using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Update;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Update
{
    public class UpdateEnduranceEventViewModel
        : PrincipalUpdateFormBase<GetEnduranceEvent, EnduranceEventForUpdateModel, UpdateEnduranceEvent>
    {
        public UpdateEnduranceEventViewModel() : base(null, null, null)
        {
        }

        public UpdateEnduranceEventViewModel(
            IApplicationService application,
            IEventAggregator eventAggregator,
            INavigationService navigation)
            : base(application, eventAggregator, navigation)
        {
            var createCompetition = this.GetCreateDelegate<CompetitionDependantView>();
            this.AddCompetition = new DelegateCommand(createCompetition);
        }

        public DelegateCommand AddCompetition { get; }

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

        private string presidentGroundJury;
        public string PresidentGroundJury
        {
            get => this.presidentGroundJury;
            set => this.SetProperty(ref this.presidentGroundJury, value);
        }

        private string presidentVetCommission;
        public string PresidentVetCommission
        {
            get => this.presidentVetCommission;
            set => this.SetProperty(ref this.presidentVetCommission, value);
        }

        private string foreignJudge;
        public string ForeignJudge
        {
            get => this.foreignJudge;
            set => this.SetProperty(ref this.foreignJudge, value);
        }

        private string feiTechDelegate;
        public string FeiTechDelegate
        {
            get => this.feiTechDelegate;
            set => this.SetProperty(ref this.feiTechDelegate, value);
        }

        private string feiVetDelegate;
        public string FeiVetDelegate
        {
            get => this.feiVetDelegate;
            set => this.SetProperty(ref this.feiVetDelegate, value);
        }

        private string activeVet;
        public string ActiveVet
        {
            get => this.activeVet;
            set => this.SetProperty(ref this.activeVet, value);
        }

        private string membersOfVetCommittee;
        public string MembersOfVetCommittee
        {
            get => this.membersOfVetCommittee;
            set => this.SetProperty(ref this.membersOfVetCommittee, value);
        }

        private string membersOfJudgeCommittee;
        public string MembersOfJudgeCommittee
        {
            get => this.membersOfJudgeCommittee;
            set => this.SetProperty(ref this.membersOfJudgeCommittee, value);
        }

        private string stewards;
        public string Stewards
        {
            get => this.stewards;
            set => this.SetProperty(ref this.stewards, value);
        }

        public List<CompetitionDependantViewModel> Competitions { get; private set; } = new();
        public ObservableCollection<ListItemViewModel> CompetitionItems { get; } = new();
        private void UpdateCompetitions(CompetitionDependantViewModel competition)
        {
            this.Competitions.AddOrUpdateObject(competition);
            this.UpdateListItems();
        }

        public void UpdateListItems()
        {
            var listItems = this.Competitions
                .Select(item =>
                {
                    var updateCompetition = this.GetUpdateDelegate<CompetitionDependantView>(item);
                    var navigateToUpdate = new DelegateCommand(updateCompetition);
                    var listItem = new ListItemViewModel(item.Type, item.Name, navigateToUpdate);

                    return listItem;
                })
                .ToList();

            this.CompetitionItems.Clear();
            this.CompetitionItems.AddRange(listItems);
        }

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
    }
}
