using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Participants
{
    public class ParticipantViewModel : DependantFormBase, IMap<ParticipantDependantModel>
    {
        private readonly IHorsesContextService horsesContext;
        private readonly IAthletesContextService athletesContext;

        private ParticipantViewModel() : base(null, null)
        {
        }

        public ParticipantViewModel(
            IApplicationService application,
            INavigationService navigation,
            IHorsesContextService horsesContext,
            IAthletesContextService athletesContext)
            : base(application, navigation)
        {
            this.horsesContext = horsesContext;
            this.athletesContext = athletesContext;
            this.ToggleIsAverageSpeedInKmPhVisibility = new DelegateCommand(
                this.ToggleIsAverageSpeedInKmPhVisibilityAction);
        }

        public ObservableCollection<ComboBoxItemViewModel> HorseItems { get; } = new();
        public ObservableCollection<ComboBoxItemViewModel> AthleteItems { get; } = new();

        private string rfId;
        public string RfId
        {
            get => this.rfId;
            set => this.SetProperty(ref this.rfId, value);
        }

        public int number;
        public int Number
        {
            get => this.number;
            set => this.SetProperty(ref this.number, value);
        }

        public int? maxAverageSpeedInKmPh;
        public int? MaxAverageSpeedInKmPh
        {
            get => this.maxAverageSpeedInKmPh;
            set => this.SetProperty(ref this.maxAverageSpeedInKmPh, value);
        }

        private int horseId;
        public int HorseId
        {
            get => this.horseId;
            set => this.SetProperty(ref this.horseId, value);
        }

        private int athleteId;
        public int AthleteId
        {
            get => this.athleteId;
            set => this.SetProperty(ref this.athleteId, value);
        }

        private int categoryId;
        public int CategoryId
        {
            get => this.categoryId;
            set => this.SetProperty(ref this.categoryId, value);
        }

        protected override ListItemViewModel ToListItem(DelegateCommand command)
        {
            var listItem = new ListItemViewModel(this.Id, this.Number.ToString(), command);
            return listItem;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            this.LoadCompetitors();

            if (this.MaxAverageSpeedInKmPh.HasValue)
            {
                this.ShowMaxAverageSpeedInKmPh();
            }
        }

        public DelegateCommand ToggleIsAverageSpeedInKmPhVisibility { get; }
        public void ToggleIsAverageSpeedInKmPhVisibilityAction()
        {
            if (this.MaxAverageSpeedInKmPhVisibility == Visibility.Hidden)
            {
                this.ShowMaxAverageSpeedInKmPh();
            }
            else
            {
                this.HideMaxAverageSpeedInKmPh();
            }
        }
        private void ShowMaxAverageSpeedInKmPh()
        {
            this.MaxAverageSpeedInKmPhVisibility = Visibility.Visible;
        }
        private void HideMaxAverageSpeedInKmPh()
        {
            this.MaxAverageSpeedInKmPhVisibility = Visibility.Hidden;
            this.MaxAverageSpeedInKmPh = default;
        }

        private Visibility maxAverageSpeedInKmPhPhVisibility = Visibility.Hidden;
        public Visibility MaxAverageSpeedInKmPhVisibility
        {
            get => this.maxAverageSpeedInKmPhPhVisibility;
            set => this.SetProperty(ref this.maxAverageSpeedInKmPhPhVisibility, value);
        }

        private async Task LoadCompetitors()
        {
            var horses = await this.horsesContext.GetAll();
            var athletes = await this.athletesContext.GetAll();

            var horseItems = horses.Select(x => new ComboBoxItemViewModel(x.Id, x.Name));
            var athleteItems = athletes.Select(x => new ComboBoxItemViewModel(x.Id, $"{x.FirstName} {x.LastName}"));

            this.HorseItems.AddRange(horseItems);
            this.AthleteItems.AddRange(athleteItems);
        }
    }
}
