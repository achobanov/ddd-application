using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions.Create
{
    public class CompetitionViewModel : DependantFormBase
    {
        public CompetitionViewModel(IApplicationService application, IEventAggregator eventAggregator)
            : base(application, eventAggregator)
        {
        }
    }
}
