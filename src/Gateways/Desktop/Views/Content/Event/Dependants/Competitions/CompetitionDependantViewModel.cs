using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public class CompetitionDependantViewModel : DependantFormBase, IMap<CompetitionDependantModel>
    {
        public CompetitionDependantViewModel() : base(null)
        {
            this.LoadTypes();
        }

        public CompetitionDependantViewModel(IApplicationService application)
            : base(application)
        {
            this.LoadTypes();
        }

        public ObservableCollection<ComboBoxItemViewModel> TypeItems { get; private set; }

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

        private void LoadTypes()
        {
            var typeViewModels = ComboBoxItemViewModel.FromEnum<CompetitionType>();
            this.TypeItems = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }
    }
}
