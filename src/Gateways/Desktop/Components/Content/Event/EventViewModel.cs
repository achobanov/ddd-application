using AutoMapper;
using EnduranceJudge.Application.Events.Commands.SaveEnduranceEvent;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Core.Mappings.Converters;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event
{
    public class EventViewModel : ViewModelBase, IMapExplicitly
    {
        public EventViewModel() : base(null)
        {
        }

        public EventViewModel(IApplicationService application) : base(application)
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
            get => this.presidentGroundJury;
            set => this.SetProperty(ref this.presidentGroundJury, value);
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

        public DelegateCommand Save { get; }
        public bool HasSaved { get; private set; }

        private async Task SaveAction()
        {
            var command = this.Map<SaveEnduranceEvent>();

            await this.Application.Execute(command);
            this.HasSaved = true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (!this.Countries.Any())
            {
                this.LoadCountries();
            }

            var isEditView = navigationContext.Parameters.TryGetValue<int>("id", out var id);
            if (isEditView)
            {
                this.LoadEvent(id);
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

        private async Task LoadEvent(int id)
        {
            var getEvent = GetEnduranceEvent.New(id);
            var enduranceEvent = await this.Application.Execute(getEvent);

            this.MapFrom(enduranceEvent);
        }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<EventViewModel, SaveEnduranceEvent>()
                .MapMember(d => d.CountryIsoCode, s => s.SelectedCountryIsoCode)
                .ForMember(
                    dest => dest.MembersOfJudgeCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.MembersOfVetCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.Stewards,
                    opt => opt.ConvertUsing(StringSplitter.New));

            mapper.CreateMap<EnduranceEventForUpdateModel, EventViewModel>()
                .MapMember(d => d.SelectedCountryIsoCode, s => s.CountryIsoCode);
        }
    }
}
