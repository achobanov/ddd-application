using EnduranceJudge.Application.Events.Commands.Competitions;
using EnduranceJudge.Application.Events.Queries.Competitions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class CompetitionViewModel : FormViewModelBase<GetCompetition, SaveCompetition, CompetitionForUpdateModel>
    {
        public CompetitionViewModel(IApplicationService application) : base(application)
        {
            var typeViewModels = ComboBoxItemViewModel.FromEnum<CompetitionType>();
            this.CompetitionTypeItems = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }

        public ObservableCollection<ComboBoxItemViewModel> CompetitionTypeItems { get; }

        private CompetitionType type;
        public CompetitionType CompetitionType
        {
            get => this.type;
            set => this.SetProperty(ref this.type, value);
        }
    }
}
