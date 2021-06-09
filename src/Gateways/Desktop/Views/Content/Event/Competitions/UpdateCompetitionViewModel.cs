using EnduranceJudge.Application.Events.Commands.Competitions;
using EnduranceJudge.Application.Events.Queries.Competitions;
using EnduranceJudge.Application.Events.Queries.GetEnduranceEventsList;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class UpdateCompetitionViewModel
        : UpdateFormBase<GetCompetition, CompetitionForUpdateModel, UpdateCompetition>
    {
        public UpdateCompetitionViewModel(IApplicationService application) : base(application)
        {
            var typeViewModels = ComboBoxItemViewModel.FromEnum<CompetitionType>();
            this.CompetitionTypes = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }

        public ObservableCollection<ComboBoxItemViewModel> EnduranceEvents { get; } = new();

        public ObservableCollection<ComboBoxItemViewModel> CompetitionTypes { get; }

        public int enduranceEventId;
        public Visibility EnduranceEventVisibility { get; private set; } = Visibility.Hidden;
        public int EnduranceEventId
        {
            get => this.enduranceEventId;
            set => this.SetProperty(ref this.enduranceEventId, value);
        }

        private int type;
        public int Type
        {
            get => this.type;
            set => this.SetProperty(ref this.type, value);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.LoadEnduranceEvents();
        }

        private async Task LoadEnduranceEvents()
        {
            var query = new GetEnduranceEventsList();

            var enduranceEvents = await this.Application.Execute(query);
            var comboBoxItems = enduranceEvents.MapEnumerable<ComboBoxItemViewModel>();

            this.EnduranceEvents.Clear();
            this.EnduranceEvents.AddRange(comboBoxItems);

            this.EnduranceEventVisibility = Visibility.Visible;
        }
    }
}
