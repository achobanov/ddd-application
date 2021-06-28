using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Personnel;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Roots.EnduranceEvents
{
    public interface ICompetitionsShard<T> : IPrincipalForm, IHasView<CompetitionView>
        where T : DependantFormBase
    {
        ObservableCollection<ListItemViewModel> CompetitionItems { get; }

        List<T> Competitions { get; }

        DelegateCommand NavigateToCompetition { get; }
    }

    public interface IPersonnelShard<T> : IPrincipalForm, IHasView<PersonnelView>
        where T : DependantFormBase
    {
        ObservableCollection<ListItemViewModel> PersonnelItems { get; }

        List<T> Personnel { get; }

        DelegateCommand NavigateToPersonnel { get; }
    }
}
