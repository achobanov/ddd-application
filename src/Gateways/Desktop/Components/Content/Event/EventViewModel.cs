using EnduranceJudge.Application.Events.Commands;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event
{
    public class EventViewModel : ViewModelBase
    {
        private IReadOnlyList<CountryListingModel> countries;

        public EventViewModel(IMediator mediator) : base(mediator)
        {
            this.Save = new AsyncCommand(this.SaveAction);
        }

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

        private int countryIsoCode;
        public Visibility CountryVisibility = Visibility.Hidden;
        public int CountryIsoCode
        {
            get => this.countryIsoCode;
            set => this.SetProperty(ref this.countryIsoCode, value);
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

            this.countries = countries.AsReadOnly();
        }

        private async Task SaveAction()
        {
            var command = new SaveEvent
            {
                Name = this.name,
                PopulatedPlace = this.populatedPlace,
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
