using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public class CompetitionDependantViewModel : DependantFormBase<CompetitionDependantViewModel>
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

        public ObservableCollection<ComboBoxItemViewModel> CompetitionTypes { get; private set; }

        private int type;
        public int Type
        {
            get => this.type;
            set => this.SetProperty(ref this.type, value);
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
            this.CompetitionTypes = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }
    }
}
