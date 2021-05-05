using EnduranceJudge.Application.Events.Commands;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event
{
    public class EventViewModel : ViewModelBase
    {
        public EventViewModel(IMediator mediator) : base(mediator)
        {
            this.Save = new AsyncCommand(this.SaveAction);
        }

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

        private string selectedSelectedCountryIsoCode;
        public Visibility CountryVisibility = Visibility.Hidden;
        public string SelectedCountryIsoCode
        {
            get => this.selectedSelectedCountryIsoCode;
            set => this.SetProperty(ref this.selectedSelectedCountryIsoCode, value);
        }

        private List<int> personnelIds;
        public List<int> PersonnelIds
        {
            get => this.personnelIds;
            set => this.SetProperty(ref this.personnelIds, value);
        }

        public DelegateCommand Save { get; }
        public bool HasSaved { get; private set; }

        private async Task LoadCountries()
        {
            var countries = await this.Mediator
                .Send(new GetCountriesListing())
                .ToList();

            this.CountryVisibility = Visibility.Visible;

            this.Countries.AddRange(countries);
        }

        private async Task SaveAction()
        {
            var command = new SaveEvent
            {
                Name = this.name,
                PopulatedPlace = this.populatedPlace,
                CountryIsoCode = this.SelectedCountryIsoCode,
            };

            await this.Mediator.Send(command);
            this.HasSaved = true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.LoadCountries();
        }
    }
}
