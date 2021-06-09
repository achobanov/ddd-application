using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Update;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Core.Mappings.Converters;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions;
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
        : PrincipalUpdateFormBase<GetEnduranceEvent, EnduranceEventForUpdateModel, UpdateEnduranceEvent>,
        IMapExplicitly
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
            this.AddDependent<CompetitionDependentViewModel>(this.Add);
            this.AddCompetition = new DelegateCommand(this.ChangeTo<CompetitionDependentView>);
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

        public List<CompetitionDependentViewModel> Competitions { get; set; } = new();

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<UpdateEnduranceEventViewModel, UpdateEnduranceEvent>()
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

            mapper.CreateMap<EnduranceEventForUpdateModel, UpdateEnduranceEventViewModel>()
                .MapMember(d => d.SelectedCountryIsoCode, s => s.CountryIsoCode);
        }

        private void Add(CompetitionDependentViewModel competition)
        {
            this.Competitions.Add(competition);
        }
    }
}
