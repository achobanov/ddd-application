using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Phases;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public interface IPhasesShard<T> : IPrincipalForm, IHasView<PhaseView>
        where T : DependantFormBase
    {
        ObservableCollection<ListItemViewModel> PhaseItems { get; }

        List<T> Phases { get; }

        DelegateCommand NavigateToCreatePhase { get; }
    }
}
