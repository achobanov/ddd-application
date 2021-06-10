using EnduranceJudge.Application.Events.Queries.CompetitionsList;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions.List
{
    public class CompetitionListViewModel
        : ListViewModelBase<GetCompetitionsList, CompetitionDependantView, CompetitionDependantView>
    {
        public CompetitionListViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
        }

        public ObservableCollection<ListItemViewModel> Competitions => this.ListItems;
    }
}
