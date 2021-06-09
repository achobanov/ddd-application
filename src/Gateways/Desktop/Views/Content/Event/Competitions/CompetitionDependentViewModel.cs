using AutoMapper;
using EnduranceJudge.Application.Events.Commands.CreateEnduranceEvent.Models;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Events;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class CompetitionDependentViewModel : DependantFormBase, IMapExplicitly
    {
        public CompetitionDependentViewModel()
        {
        }

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

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<CompetitionDependentViewModel, CreateCompetitionModel>()
                .MapMember(d => d.Type, s => (CompetitionType) s.Type);
        }
    }
}
