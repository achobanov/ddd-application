using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions.Create
{
    public class CreateCompetitionViewModel : CreateFormBase
    {
        public CreateCompetitionViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}
