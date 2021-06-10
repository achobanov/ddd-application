using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create.Models;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Events;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class CompetitionDependentViewModel : DependantFormBase
    {
        public CompetitionDependentViewModel(IApplicationService application, IEventAggregator eventAggregator)
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
    }
}
