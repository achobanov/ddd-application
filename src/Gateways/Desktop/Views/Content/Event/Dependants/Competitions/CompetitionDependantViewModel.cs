using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public class CompetitionDependantViewModel : DependantFormBase
    {
        public CompetitionDependantViewModel() : base(null)
        {
            this.LoadCompetitionTypes();
        }

        public CompetitionDependantViewModel(IApplicationService application)
            : base(application)
        {
            this.LoadCompetitionTypes();
        }

        public ObservableCollection<ComboBoxItemViewModel> CompetitionTypeItems { get; private set; }

        private int competitionType;
        public int CompetitionType
        {
            get => this.competitionType;
            set => this.SetProperty(ref this.competitionType, value);
        }

        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        private void LoadCompetitionTypes()
        {
            var typeViewModels = ComboBoxItemViewModel.FromEnum<CompetitionType>();
            this.CompetitionTypeItems = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }
    }
}
