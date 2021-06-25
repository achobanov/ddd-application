using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents
{
    public interface ICompetitionsShard<T> : IPrincipalForm, IHasView<CompetitionDependantView>
        where T : DependantFormBase
    {
        List<T> Competitions { get; }

        ObservableCollection<ListItemViewModel> CompetitionItems { get; }

        DelegateCommand NavigateToCompetition { get; }
    }
}
