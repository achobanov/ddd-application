using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Prism.Events;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public class CompetitionDependantViewModel : DependantFormBase
    {
        public CompetitionDependantViewModel() : base(null, null)
        {
        }

        public CompetitionDependantViewModel(IApplicationService application, IEventAggregator eventAggregator)
            : base(application, eventAggregator)
        {
            var typeViewModels = ComboBoxItemViewModel.FromEnum<CompetitionType>();
            this.CompetitionTypes = new ObservableCollection<ComboBoxItemViewModel>(typeViewModels);
        }

        public ObservableCollection<ComboBoxItemViewModel> CompetitionTypes { get; }

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
    }
}
