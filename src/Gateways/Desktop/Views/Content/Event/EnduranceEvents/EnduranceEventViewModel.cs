using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
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
    public class EnduranceEventViewModel : RootFormBase<SaveEnduranceEvent, EnduranceEventForUpdateModel>
    {
        protected EnduranceEventViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
            var createCompetition = this.NavigateToDependantCreateDelegate<CompetitionDependantView>(
                this.UpdateCompetitions);

            var navigateToPersonnel = this.NavigateToDependantCreateDelegate<PersonnelView>(
                this.UpdatePersonnel);

            this.AddCompetition = new DelegateCommand(createCompetition);
            this.AddPersonnel = new DelegateCommand(navigateToPersonnel);
        }

        public DelegateCommand AddCompetition { get; }
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
        private void UpdatePersonnel(object obj)
        {
            if (obj is not PersonnelViewModel personnel)
            {
                return;
            }

            this.Personnel.AddOrUpdateObject(personnel);
            this.UpdatePersonnelItems();
        }

        public void UpdatePersonnelItems()
        {
            var listItems = this.Personnel
                .Select(this.ConvertToListItem)
                .ToList();

            this.PersonnelItems.Clear();
            this.PersonnelItems.AddRange(listItems);
        }

        private ListItemViewModel ConvertToListItem(PersonnelViewModel personnel)
        {
            var update = this.NavigateToDependantUpdateDelegate<PersonnelView>(
                personnel,
                this.UpdatePersonnel);

            var navigateToUpdate = new DelegateCommand(update);
            var display = $"{(PersonnelRole)personnel.Role} - {personnel.Name}";

            var listItem = new ListItemViewModel(personnel.Id, display, navigateToUpdate);

            return listItem;
        }

        public List<CompetitionDependantViewModel> Competitions { get; private set; } = new();
        public ObservableCollection<ListItemViewModel> CompetitionItems { get; } = new();
        private void UpdateCompetitions(object obj)
        {
            if (obj is not CompetitionDependantViewModel competition)
            {
                return;
            }

            this.Competitions.AddOrUpdateObject(competition);
            this.UpdateCompetitionItems();
        }

        public void UpdateCompetitionItems()
        {
            var listItems = this.Competitions
                .Select(this.ConvertToListItem)
                .ToList();

            this.CompetitionItems.Clear();
            this.CompetitionItems.AddRange(listItems);
        }

        private ListItemViewModel ConvertToListItem(CompetitionDependantViewModel competition)
        {
            var updateCompetition = this.NavigateToDependantUpdateDelegate<CompetitionDependantView>(
                competition,
                this.UpdateCompetitions);

            var navigateToUpdate = new DelegateCommand(updateCompetition);
            var listItem = new ListItemViewModel(competition.Id, competition.Name, navigateToUpdate);

            return listItem;
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

        protected override IRequest<EnduranceEventForUpdateModel> LoadCommand(int id)
        {
            return new GetEnduranceEvent
            {
                Id = id,
            };
        }
    }
}
