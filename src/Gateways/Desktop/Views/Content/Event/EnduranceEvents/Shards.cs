using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Personnel;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents
{
    public interface ICompetitionsShard<T> : IPrincipalForm, IHasView<CompetitionView>
        where T : DependantFormBase
    {
        List<T> Competitions { get; }

        ObservableCollection<ListItemViewModel> CompetitionItems { get; }

        DelegateCommand NavigateToCompetition { get; }
    }

    public interface IPersonnelShard<T> : IPrincipalForm, IHasView<PersonnelView>
        where T : DependantFormBase
    {
        List<T> Personnel { get; }

        ObservableCollection<ListItemViewModel> PersonnelItems { get; }

        DelegateCommand NavigateToPersonnel { get; }
    }
}
